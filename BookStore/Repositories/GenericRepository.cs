using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BookStoreDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(BookStoreDbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if(entity != null)
            {
                return entity;
            }
            throw new Exception("Not found entity");
        }
        
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if(entity != null)
            {

                _dbSet.Remove(entity);
            }
            await _context.SaveChangesAsync();
        }
    }
}
