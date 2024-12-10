using Microsoft.EntityFrameworkCore;
using ProductCatalog.Core.Interfaces;
using ProductCatalog.DataAcess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAcess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T :class 
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);

        }

        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<bool> ExistAsync(int id)
        {
            var item = await dbSet.FindAsync(id);
            return item != null;
        }


        public async Task<T> FindAsync(Expression<Func<T, bool>> critera, string[] includes = null)
        {
            IQueryable<T> query = dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync(critera);
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> critera, string[] includes = null)
        {
            IQueryable<T> query = dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.Where(critera).ToListAsync();
        }




        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Update(T entity)
        {
            dbSet.Update(entity);
            return entity;
        }


    }
}
