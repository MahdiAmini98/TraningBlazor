using TraningBlazorProject.Client.Models;
namespace TraningBlazorProject.Repositories
{
    public interface IProductRepository
    {
        List<ProductDto> GetProducts();
    }


    public class ProductRepository : IProductRepository
    {
        private readonly List<ProductDto> _products = new()
         {
        new ProductDto { Id = 1, Name = "Laptop", Price = 1200 },
        new ProductDto { Id = 2, Name = "Phone", Price = 800 }
         };

        public List<ProductDto> GetProducts() => _products;
    }
}
