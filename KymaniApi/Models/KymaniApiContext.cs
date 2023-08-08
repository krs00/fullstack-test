using Microsoft.EntityFrameworkCore;

namespace KymaniApi.Models
{
  public class KymaniApiContext : DbContext
  {
    public DbSet<Kymani> Kymanis { get; set; }
    public KymaniApiContext(DbContextOptions<KymaniApiContext> options) : base(options) 
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Kymani>()
        .HasData(
          new Kymani { KymaniId = 1, Mood = "Happy", PowerLevel = 12 },
          new Kymani { KymaniId = 2, Mood = "Cool", PowerLevel = 9001 } 
        );
    }


  }
}