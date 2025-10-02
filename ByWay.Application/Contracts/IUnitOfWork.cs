using ByWay.Domain.Entities;
using ByWay.Domain.Entities.Cart;

namespace ByWay.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Course> Courses { get; }
        IGenericRepository<Instructor> Instructors { get; }
        IGenericRepository<Carts> Carts { get; }  
        IGenericRepository<CartItem> CartItems { get; }
        Task<int> CompleteAsync();
    }
}
