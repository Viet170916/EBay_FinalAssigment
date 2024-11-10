using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class EBayDbContext(DbContextOptions<EBayDbContext> options) : DbContext(options)
{
  public DbSet<User> Users { get; set; }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    // Define relationships here if necessary
  }
}