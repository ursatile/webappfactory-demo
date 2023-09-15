namespace ApiServer;

public class Program {
	public static void Main(string[] args) {
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();
		builder.Services.AddSingleton<IWeatherService, RandomWeatherService>();

		var app = builder.Build();

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}