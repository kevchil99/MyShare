using AssessmentApi.Models;
using AssessmentApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        public BackEndApi backEndApi = new BackEndApi();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<List<PollDirection>> Get()
        {
            var api1 = backEndApi.GetApi1();
            var api2 = backEndApi.GetApi2();
            await Task.WhenAll(api1, api2);

            // Retrieve the results.
            var result1 = api2.Result;

            return result1;
        }

        //[RequiredScope("access_as_user")] can implement RequiredScopeAttribute Class
        //[AllowedAudience]
        //[Authorize]
        [HttpPost(Name = "PostWeatherForecast")]
        public async Task<List<WeatherForecast>> Post()
        {
            var api1 = backEndApi.GetApi1();
            var api2 = backEndApi.GetApi2();
            await Task.WhenAll(api1, api2);

            // Retrieve the results.
            var result1 = api1.Result;

            return result1;
        }
    }
}
