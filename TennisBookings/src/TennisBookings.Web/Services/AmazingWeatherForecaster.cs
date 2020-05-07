
using System.Threading.Tasks;
using TennisBookings.Web.Domain;

namespace TennisBookings.Web.Services
{
    public class AmazingWeatherForecaster : IWeatherForecaster
    {
        public WeatherResult GetCurrentWeather()
        {
            // DO SOMETHING AMAZING HERE!!!

            return new WeatherResult
            {
                WeatherCondition = WeatherCondition.Sun
            };
        }

        public Task<CurrentWeatherResult> GetCurrentWeatherAsync()
        {
            throw new System.NotImplementedException();
        }

        object IWeatherForecaster.GetCurrentWeather()
        {
            throw new System.NotImplementedException();
        }
    }
}
