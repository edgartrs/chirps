using Microsoft.EntityFrameworkCore;
namespace Chirps.Models 
{
  public class Chirp
  {
    public Guid Id { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
  }

  public class ChirpsDbContext : DbContext
  {
    public ChirpsDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Chirp> Chirps { get; set; }
  }
}