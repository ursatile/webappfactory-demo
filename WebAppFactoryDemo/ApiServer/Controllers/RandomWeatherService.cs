using ApiServer;

public class RandomWeatherService : IWeatherService {
	private static readonly string[] summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};
	public IEnumerable<WeatherForecast> GetForecasts() {
		return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
			Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
			TemperatureC = Random.Shared.Next(-20, 55),
			Summary = summaries[Random.Shared.Next(summaries.Length)]
		});
	}
}