using TraningBlazorProject.Client.Models;
using TraningBlazorProject.Client.Services.ProductServices;
using TraningBlazorProject.Repositories;

namespace TraningBlazorProject.Services
{
    public class ServerProductService(IProductRepository productRepository) : IProductService
    {

        public Task<List<ProductDto>> GetProductsAsync()
        {
            return Task.FromResult(productRepository.GetProducts());
        }
    }
}
 