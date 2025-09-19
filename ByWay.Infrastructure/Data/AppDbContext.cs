namespace ByWay.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);
        }

        public DbSet<Category>Categories { get; set; }
        public DbSet<Course>Courses { get; set; }
        public DbSet<Instructor>Instructors { get; set; }
        public DbSet<CourseSection>CourseSections { get; set; }
        public DbSet<Lectur>Lectures { get; set; }



    }
}
