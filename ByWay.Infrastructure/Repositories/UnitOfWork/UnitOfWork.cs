using ByWay.Infrastructure.Services.Repositories;

namespace ByWay.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IGenericRepository<Course> Courses { get; private set; }
        public IGenericRepository<Instructor> Instructors { get; private set; }
        public IGenericRepository<Carts> Carts { get; private set; }
        public IGenericRepository<CartItem> CartItems { get; private set; }
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Courses = new GenericRepository<Course>(_dbContext);
            Instructors = new GenericRepository<Instructor>(_dbContext);
            Carts = new GenericRepository<Carts>(_dbContext);
            CartItems = new GenericRepository<CartItem>(_dbContext);
        }
       
        public async Task<int> CompleteAsync()=>await _dbContext.SaveChangesAsync();

        public void Dispose() => _dbContext.Dispose();
    }
}
