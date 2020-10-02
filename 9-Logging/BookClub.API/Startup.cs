using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookClub.Data;
using BookClub.Infrastructure.Middleware;
using BookClub.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BookClub.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDbConnection, SqlConnection>(p =>
                new SqlConnection(Configuration.GetConnectionString("BookClubDb")));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookLogic, BookLogic>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfig>();

            services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    options.Authority = Configuration.GetValue<string>("Security:Authority");
                    options.Audience = Configuration.GetValue<string>("Security:Audience");
                });

            services.AddAuthorization();

            services.AddSwaggerGen();

            services.AddMvc(options =>
            {
                var builder = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser();
                options.Filters.Add(new AuthorizeFilter(builder.Build()));
                //options.Filters.Add(typeof(TrackActionPerformanceFilter));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseHsts();
            //}
            app.UseApiExceptionHandler(options => options.AddResponseDetails = UpdateApiErrorResponse);

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Book Club API");
                options.OAuthClientId(Configuration.GetValue<string>("Security:ClientId"));
                options.OAuthClientSecret(Configuration.GetValue<string>("Security:ClientSecret"));
                options.OAuthAppName("Book Club API");
                options.OAuthUsePkce();
            });
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void UpdateApiErrorResponse(HttpContext context, Exception ex, ApiError error)
        {
            if (ex.GetType().Name == nameof(SqlException))
            {
                error.Detail = "Exception was a database exception!";
            }
            //error.Links = "https://gethelpformyerror.com/";
        }
    }
}
