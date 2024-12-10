

namespace ProductCatalog.Core.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetActiveProductsAsync();
    }
}
