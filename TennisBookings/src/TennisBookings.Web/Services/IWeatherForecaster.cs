using System.Threading.Tasks;
using TennisBookings.Web.Domain;
using TennisBookings.Web.External.Models;

namespace TennisBookings.Web.Services
{
    public interface IWeatherForecaster
    {
        Task<CurrentWeatherResult> GetCurrentWeatherAsync();
        WeatherApiResult GetCurrentWeather();
    }
}