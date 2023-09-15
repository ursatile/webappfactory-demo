using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers {
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase {

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IWeatherService _weatherService;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService) {
			_logger = logger;
			_weatherService = weatherService;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get() => _weatherService.GetForecasts();
	}
}