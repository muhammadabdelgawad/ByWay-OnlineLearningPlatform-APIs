using ByWay.Application.Contracts;

namespace ByWay.Infrastructure.Services.Repositories
{
    public class GenericRepository<T>(AppDbContext dbContext) : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();
        
        public async Task<T?> GetByIdAsync(int id) =>  await _dbContext.Set<T>().FindAsync(id);

        public async Task AddAsync(T entity) => await _dbContext.Set<T>().AddAsync(entity);
        
        public void Update(T entity) => _dbContext.Set<T>().Update(entity);
        public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);



    }
}
