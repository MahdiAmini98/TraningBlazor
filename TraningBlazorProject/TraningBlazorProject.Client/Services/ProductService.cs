namespace TraningBlazorProject.Client.Services
{
    public class ProductService
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            _products = Enumerable.Range(1, 1000).Select(i => new Product
            {
                Id = i,
                Name = "Product " + i,
                Description = "This is Description of The Product" + i,
                Price = i * Random.Shared.Next(1000, 10000000)
            }).ToList();
        }

        // دریافت داده بدون صفحه بندی
        public Task<(List<Product> products, int totalCount)> GetProductsAsync()
        {
            var products = _products.ToList();

            return Task.FromResult((products, products.Count));
        }

        // دریافت داده با صفحه بندی
        public Task<(List<Product> products, int totalCount)> GetProductsPagedAsync(int startIndex, int count)
        {
            var pageinationProducts = _products.Skip(startIndex).Take(count).ToList();
            return Task.FromResult((pageinationProducts, _products.Count));
        }

    }
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
