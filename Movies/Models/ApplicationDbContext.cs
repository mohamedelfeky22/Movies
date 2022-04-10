

namespace Movies.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
    }
}
