using Microsoft.EntityFrameworkCore;
using DistrictWebapp.Models;


namespace DistrictWebapp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        public DbSet<City> Cities { get; set; } 
        public DbSet<District> Districts { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(c => c.Districts)
                .WithOne(d => d.City)
                .HasForeignKey(d => d.CityId);
        }

    }
}
