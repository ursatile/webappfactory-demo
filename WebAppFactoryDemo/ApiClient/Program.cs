using RestSharp;

var options = new RestClientOptions("http://localhost:5279");
var client = new RestClient(options);
var request = new RestRequest("/weatherforecast");
var response = await client.GetAsync(request);
Console.WriteLine(response.Content);
