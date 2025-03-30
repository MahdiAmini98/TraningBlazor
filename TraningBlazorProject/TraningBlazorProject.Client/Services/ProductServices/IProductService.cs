using System.Net.Http.Json;
using TraningBlazorProject.Client.Models;

namespace TraningBlazorProject.Client.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProductsAsync();

    }

    public class ClientProductService(HttpClient _httpClient) : IProductService
    {
        public async Task<List<ProductDto>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductDto>>("api/products") ?? new List<ProductDto>();
        }
    }
}
