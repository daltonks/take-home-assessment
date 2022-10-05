using System.Collections.Generic;
using Coterie.Domain.WeatherForecasts;

namespace Coterie.Services.Tests
{
    public interface ITestService
    {
        IEnumerable<WeatherForecastResponse> GetWeatherItems(string[] items);
    }
}