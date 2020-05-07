using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using TennisBookings.Web.Configuration;
using TennisBookings.Web.Services;

namespace TennisBookings.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWeatherForecaster _weatherForecaster;
        private readonly IHomePageGreetingService _greetingService;
        private readonly FeaturesConfiguration _featuresConfiguration;
        private readonly IConfiguration _configuration;

        public string Greeting { get; private set; }

        public bool ShowGreeting => !string.IsNullOrEmpty(Greeting);
        
        public string WeatherDescription { get; private set; } =
            "We don't have the latest weather information right now, please check again later.";

        public IndexModel(
            IWeatherForecaster weatherForecaster, 
            IOptions<FeaturesConfiguration> options, 
            IHomePageGreetingService greetingService, IConfiguration configuration)
        {
            _weatherForecaster = weatherForecaster;
            _greetingService = greetingService;
            _featuresConfiguration = options.Value;
            _configuration = configuration;    
        }

        public async Task OnGet()
        {
            var x = _configuration.GetValue<bool>("Features:HomePage:EnableGreeting"); //accessing the configuration at runtime

            var homePageFeatures = _configuration.GetSection("Features:HomePage");
            homePageFeatures.GetValue<bool>("EnableGreeting");

            var features = new Features();
            _configuration.Bind("Features:HomePage", features);

            Greeting = _greetingService.GetRandomHomePageGreeting();            

            if (_featuresConfiguration.EnableWeatherForecast)
            {
                var currentWeather = await _weatherForecaster.GetCurrentWeatherAsync();

                switch (currentWeather.Description)
                {
                    case "Sun":
                        WeatherDescription = "It's sunny right now. A great day for tennis!";
                        break;

                    case "Cloud":
                        WeatherDescription = "It's cloudy at the moment and the outdoor courts are in use.";
                        break;

                    case "Rain":
                        WeatherDescription = "We're sorry but it's raining here. No outdoor courts in use.";
                        break;

                    case "Snow":
                        WeatherDescription = "It's snowing!! Outdoor courts will remain closed until the snow has cleared.";
                        break;
                }
            }
        }

        private class Features
        {
            public bool EnableRandomGreeting { get; set; }
        }
    }
}
