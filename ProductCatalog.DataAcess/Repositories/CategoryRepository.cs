

using ProductCatalog.Core.Interfaces;
using ProductCatalog.DataAcess.Data;

namespace ProductCatalog.DataAcess.Repositories
{
    public class CategoryRepository : BaseRepository<Category> , ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
