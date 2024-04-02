using OneUiToRuleThemAll.Abstractions;
using OneUiToRuleThemAll.Abstractions.Models;

namespace OneUiToRuleThemAll.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly List<Product> products = new();

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(products);
        }
        public Task<Product?> GetProductAsync(Guid id)
        {
            return Task.FromResult(products.FirstOrDefault(p => p.Id == id));
        }
        public Task<Guid> AddProductAsync(ProductData data)
        {
            var product = new Product(data) with { Id = Guid.NewGuid() };
            products.Add(product);
            return Task.FromResult(product.Id);
        }
        public Task<bool> UpdateProductsAsync(Guid productId, ProductData data)
        {
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product is null)
                return Task.FromResult(false);
            products.Remove(product);
            products.Add(new Product(data) with { Id = productId });
            return Task.FromResult(true);
        }
        public Task<bool> DeleteProductAsync(Guid productId)
        {
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product is null)
                return Task.FromResult(false);
            products.Remove(product);
            return Task.FromResult(true);
        }

    }

    //public record OrderData
    //{
    //    public string Customer { get; set; }
    //    public List<OrderDetailData> Details { get; set; } = new();
    //}
    //public record OrderDetailData
    //{
    //    public Guid ProductId { get; set; }
    //    public int Quantity { get; set; }
    //}

}
