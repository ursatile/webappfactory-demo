using ApiServer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Shouldly;
using Program = ApiServer.Program;

namespace WebAppFactoryTests;

public class WebTests {
	[SetUp]
	public void Setup() {
	}

	[Test]
	public async Task GET_Forecast_Returns_Success() {
		var factory = new WebApplicationFactory<Program>();
		var client = factory.CreateClient();
		var response = await client.GetAsync("/WeatherForecast");
		response.EnsureSuccessStatusCode();
	}
}
public class ApiClientTests {
	private WeatherClient MakeClient(int temperatureC) {
		var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(webHostBuilder => {
			webHostBuilder.ConfigureServices(services => {
				var testWeatherService = new TestWeatherService(temperatureC);
				services.AddSingleton<IWeatherService>(testWeatherService);
			});
		});
		var httpClient = factory.CreateClient();
		return new WeatherClient(httpClient);
	}

	[Test]
	public async Task WeatherForecastClient_Gets_Forecast() {
		var client = MakeClient(15);
		var forecast = client.GetWeatherForecast();
		forecast.ShouldNotBeNull();
	}

	[TestCase(-8)]
	[TestCase(0)]
	[TestCase(200)]
	public async Task WeatherForecastClient_Returns_Correct_Forecast(int temperatureC) {
		var client = MakeClient(temperatureC);
		var forecast = await client.GetWeatherForecast();
		forecast.First().TemperatureC.ShouldBe(temperatureC);
	}
}


public class TestWeatherService : IWeatherService {
	private readonly int _temperatureC;

	public TestWeatherService(int temperatureC) {
		_temperatureC = temperatureC;
	}
	public IEnumerable<WeatherForecast> GetForecasts() {
		yield return new WeatherForecast() {
			Date = new DateOnly(2021, 2, 3),
			Summary = "Test Summary",
			TemperatureC = _temperatureC
		};
	}
}

/* 
 * [
    {
        "date": "2023-09-16",
        "temperatureC": 44,
        "temperatureF": 111,
        "summary": "Warm"
    },
    {
        "date": "2023-09-17",
        "temperatureC": 32,
        "temperatureF": 89,
        "summary": "Mild"
    },
    {
        "date": "2023-09-18",
        "temperatureC": 34,
        "temperatureF": 93,
        "summary": "Bracing"
    },
    {
        "date": "2023-09-19",
        "temperatureC": 38,
        "temperatureF": 100,
        "summary": "Chilly"
    },
    {
        "date": "2023-09-20",
        "temperatureC": -2,
        "temperatureF": 29,
        "summary": "Hot"
    }
] */