using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InGazAPI.Models;
using InGazAPI.Data;

namespace InGazAPI.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly InGazDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(InGazDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var result = false;
            _dbSet.Update(entity);
            if (await _context.SaveChangesAsync() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<T> CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }

}
