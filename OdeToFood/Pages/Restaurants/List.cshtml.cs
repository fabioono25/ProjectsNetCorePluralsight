using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        //input and output model
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } //another way to model binding

        //output model
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData,
                         ILogger<ListModel> logger)
        {
            this.configuration = configuration;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        //public void OnGet(string searchTerm) -- using input model
        public void OnGet()
        {
            logger.LogInformation("logging information");

            Message = configuration["Message"];

            //HttpContext.Request.Query["search-input"]

            //model binding approach
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}