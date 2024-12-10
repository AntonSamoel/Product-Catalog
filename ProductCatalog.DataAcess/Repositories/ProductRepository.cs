using Microsoft.EntityFrameworkCore;
using ProductCatalog.Core.Interfaces;
using ProductCatalog.DataAcess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAcess.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetActiveProductsAsync()
        {
            var currentDate = DateTime.UtcNow;

            IEnumerable<Product> activeProducts = await _context.Products.Where(p => currentDate >= p.StartDate && currentDate <= p.StartDate.AddDays(p.DurationInDays)).Include(p=>p.Category).ToListAsync();

            return activeProducts;



        }

    }
}
