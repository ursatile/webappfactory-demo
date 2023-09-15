using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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