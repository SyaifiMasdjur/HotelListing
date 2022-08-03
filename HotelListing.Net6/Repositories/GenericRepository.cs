using HotelListing.Net6.Contracts;
using HotelListing.Net6.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Net6.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        public readonly HotelDBContext _context;

        public GenericRepository(HotelDBContext context)
        {
            this._context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task SaveAsync()
        {
            var o = await _context.SaveChangesAsync();
        }

        public Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
