using Microsoft.EntityFrameworkCore;
using Web.Data.Seeder;
using Web.Models;

namespace Web.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Menu> Menus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        MenuSeeder.Seed(modelBuilder);
    }
}
