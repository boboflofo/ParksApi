using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Parks.Models
{
    public class ParksDbContext : IdentityDbContext<ApplicationUser>
    {
      
        public DbSet<NationalPark> NationalParks { get; set; }
        public ParksDbContext(DbContextOptions options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.Entity<StatePark>()
        .HasData(
          new StatePark { StateParkId = 1, Name = "Waterfall"},
          new StatePark { StateParkId = 2, Name = "Mountain"}
        );
      builder.Entity<NationalPark>()
        .HasData(
          new NationalPark { NationalParkId = 3, Name = "Volcano"},
          new NationalPark { NationalParkId = 4, Name = "Ocean"}
        );
    }
    }

}