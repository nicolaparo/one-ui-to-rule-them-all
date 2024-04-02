using OneUiToRuleThemAll.Abstractions.Models;

namespace OneUiToRuleThemAll.Abstractions
{
    public interface ICatalogService
    {
        Task<Guid> AddProductAsync(ProductData data);
        Task<bool> DeleteProductAsync(Guid productId);
        Task<Product?> GetProductAsync(Guid id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<bool> UpdateProductsAsync(Guid productId, ProductData data);
    }
}