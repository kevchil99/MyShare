using AssessmentApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectionsController : ControllerBase
    {
        private static readonly string[] PollDireactions = new[]
        {
            "North", "South", "East", "West"
        };

        private readonly ILogger<DirectionsController> _logger;

        public DirectionsController(ILogger<DirectionsController> logger)
        {
            _logger = logger;
        }

        //[RequiredScope("access_as_user")] can implement RequiredScopeAttribute Class
        //
        [HttpGet(Name = "GetBackEnd2")]
        public IEnumerable<PollDirection> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new PollDirection
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = PollDireactions[Random.Shared.Next(PollDireactions.Length)]
            })
            .ToList();
        }
    }
}
