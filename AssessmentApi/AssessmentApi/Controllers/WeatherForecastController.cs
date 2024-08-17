using AssessmentApi.Models;
using AssessmentApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        private readonly IBackEndApiService _backEndApiService;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory, IBackEndApiService backEndApiService)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _backEndApiService = backEndApiService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<List<PollDirection>> Get()
        {
            var api1 = _backEndApiService.GetApi1();
            var api2 = _backEndApiService.GetApi2();
            await Task.WhenAll(api1, api2);

            // Retrieve the results.
            //TODO: Depending in return aggregate response, create response handler
            var result1 = api2.Result;

            return result1;
        }

        //[RequiredScope("access_as_user")] can implement RequiredScopeAttribute Class
        //[AllowedAudience]
        //[Authorize]
        [HttpPost(Name = "PostWeatherForecast")]
        public async Task<List<WeatherForecast>> Post()
        {
            var api1 = _backEndApiService.GetApi1();
            var api2 = _backEndApiService.GetApi2();
            await Task.WhenAll(api1, api2);

            // Retrieve the results.
            //TODO: Depending in return aggregate response, create response handler
            var result1 = api1.Result;

            return result1;
        }
    }
}
