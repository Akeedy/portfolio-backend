using Microsoft.EntityFrameworkCore;
namespace portfolio_backend.Models{

    public class ApplicationDbContext:DbContext{

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            

        }
        DbSet<Project> Projects{get;set;}
        // // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        // // {
        // //     optionsBuilder.UseNpgsql("User ID=orhan;Password=12345;Server=localhost;Port=5432;Database=portfolio;Integrated Security=true;Pooling=true;");
    // }
    }
}