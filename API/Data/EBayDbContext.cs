using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class EBayDbContext(DbContextOptions<EBayDbContext> options) : DbContext(options)
{
  public DbSet<User> Users { get; set; }
  public DbSet<Product> Products { get; set; }
   public DbSet<Address> Addresses { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    // Define relationships here if necessary
  }
}