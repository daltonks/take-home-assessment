using System.Linq;
using Coterie.Api.Models.Responses;
using Coterie.Domain.Tests;
using Coterie.Domain.WeatherForecasts;
using Coterie.Services.Tests;
using Microsoft.AspNetCore.Mvc;

namespace Coterie.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : CoterieBaseController
    {
        private readonly ITestService _testService;
        
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpPost]
        public ActionResult<ItemsResponse<WeatherForecastResponse>> Get(TestRequest request)
        {
            var result = _testService.GetWeatherItems(request.Seasons);
            return new ItemsResponse<WeatherForecastResponse>
            {
                Items = result.ToList()
            };
        }
    }
}