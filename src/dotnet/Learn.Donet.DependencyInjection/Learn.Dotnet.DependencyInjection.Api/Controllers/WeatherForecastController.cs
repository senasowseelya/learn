using Microsoft.AspNetCore.Mvc;

namespace Learn.Dotnet.DependencyInjection.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        readonly IGreet greetingService;
        
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IGreet greetingService)
        {
             this.greetingService = greetingService;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            greetingService.Greet();
            return [];
        }
    }
}
