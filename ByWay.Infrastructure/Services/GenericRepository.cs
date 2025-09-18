using ByWay.Application.Interfaces;

namespace ByWay.Infrastructure.Services
{
    public class GenericRepository<T>(AppDbContext dbContext) : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();
        
        public async Task<T> GetByIdAsync(int id) =>  await _dbContext.Set<T>().FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            var entry = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

    }
}
