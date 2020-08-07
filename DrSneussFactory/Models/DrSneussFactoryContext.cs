using Microsoft.EntityFrameworkCore;

namespace DrSneussFactory.Models
{
  public class DrSneussFactoryContext : DbContext
  {
    public virtual DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<EngineerMachine> EngineerMachine { get; set; }

    public DrSneussFactoryContext(DbContextOptions options) : base(options) { }
  }
}