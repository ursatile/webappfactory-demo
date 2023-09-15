﻿using RestSharp;

var client = new WeatherClient();
var forecast = await client.GetWeatherForecast();
Console.WriteLine(forecast);

public class WeatherClient {
	private readonly RestClient restClient;
	readonly RestClientOptions options = new("http://localhost:5279");
	/// <summary>Construct a new weatherclient using a provided HTTP client</summary>
	/// <param name="httpClient"></param>
	public WeatherClient(HttpClient httpClient) {
		this.restClient = new RestClient(httpClient, options);
	}

	public WeatherClient() {
		this.restClient = new RestClient(options);
	}

	public async Task<string?> GetWeatherForecast() {
		var request = new RestRequest("/weatherforecast");
		var response = await restClient.GetAsync(request);
		return response.Content;
	}
}