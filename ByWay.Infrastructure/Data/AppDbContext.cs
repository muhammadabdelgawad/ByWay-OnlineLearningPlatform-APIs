using ByWay.Domain.Entities.Cart;
using ByWay.Infrastructure.Data.Configurations.Base;
using ByWay.Infrastructure.Data.Configurations.Cart;
using ByWay.Infrastructure.Data.Configurations.Categories;
using ByWay.Infrastructure.Data.Configurations.Courses;
using ByWay.Infrastructure.Data.Configurations.Instructors;
using ByWay.Infrastructure.Data.Configurations.Lecture;

namespace ByWay.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartConfigrations());
            modelBuilder.ApplyConfiguration(new CartItemConfigrations());
            modelBuilder.ApplyConfiguration(new CourseConfigurations());
            modelBuilder.ApplyConfiguration(new CourseSectionConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new InstructorConfigurations());
            modelBuilder.ApplyConfiguration(new LectureConfigurations());
        }

        public DbSet<Category>Categories { get; set; }
        public DbSet<Course>Courses { get; set; }
        public DbSet<Instructor>Instructors { get; set; }
        public DbSet<CourseSection>CourseSections { get; set; }
        public DbSet<Lectur>Lectures { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

       


    }
}
