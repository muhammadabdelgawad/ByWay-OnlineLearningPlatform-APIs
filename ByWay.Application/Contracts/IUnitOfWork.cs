using ByWay.Domain.Entities;

namespace ByWay.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Course> Courses { get; }
        IGenericRepository<Instructor> Instructors { get; }

        Task<int> CompleteAsync();
    }
}
