using System.Text;
using System.Text.Json;
using ProductService.Dtos;

namespace ProductService.SyncDataServices.Http;
public class HttpOrderDataClient : IOrderDataClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public HttpOrderDataClient(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }
    public async Task SendProductToOrder(ProductReadDto prod)
    {
        var httpContent = new StringContent(JsonSerializer.Serialize(prod), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_config["OrderService"], httpContent);
        if(response.IsSuccessStatusCode)
            Console.WriteLine(" --> Sync Post to orders service is OK");
        else
            Console.WriteLine(" --> Sync Post to orders service is NOT OK");
    }
}
