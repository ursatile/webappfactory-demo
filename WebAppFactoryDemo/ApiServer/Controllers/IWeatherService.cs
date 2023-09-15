using ApiServer;

public interface IWeatherService {
	public IEnumerable<WeatherForecast> GetForecasts();
}