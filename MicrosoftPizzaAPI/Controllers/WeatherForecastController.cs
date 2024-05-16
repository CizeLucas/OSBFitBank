using Microsoft.AspNetCore.Mvc;
using MicrosoftPizzaAPI.Models;

namespace PublicationsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private IEnumerable<WeatherForecast> weather;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            weather = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            return Ok(weather);
        }

        [HttpGet("{id}", Name = "GetWeatherForecastById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<WeatherForecast>> Get(int id)
        {
            var weatherValue = weather.ElementAtOrDefault<WeatherForecast>(id);
            if (weatherValue == null)
                return NotFound();

            return Ok(weatherValue);
        }
    }
}
