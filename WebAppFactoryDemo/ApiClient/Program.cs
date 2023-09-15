using RestSharp;

var client = new WeatherClient();
var forecast = await client.GetWeatherForecast();
Console.WriteLine(forecast);

public class WeatherClient {
	private readonly RestClient restClient;

	public WeatherClient() {
		var options = new RestClientOptions("http://localhost:5279");
		this.restClient = new RestClient(options);
	}

	public async Task<string?> GetWeatherForecast() {
		var request = new RestRequest("/weatherforecast");
		var response = await restClient.GetAsync(request);
		return response.Content;
	}
}