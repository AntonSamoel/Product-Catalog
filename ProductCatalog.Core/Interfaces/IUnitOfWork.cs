
namespace ProductCatalog.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        public int Save();
    }
}
