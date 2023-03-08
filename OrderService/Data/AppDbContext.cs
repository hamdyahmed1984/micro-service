using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Data;
public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt)
    {
        
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Entity<Order>()
        .HasMany(p => p.Products);

    }

}