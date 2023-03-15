using KDT.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace KDT.Web.Database;

public class KdtDbContext : DbContext
{
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: @"Data Source=C:\Users\KonDzik\source\repos\KonDzikToolbox\kdt.sqlite;");
    }
    
    public DbSet<SmallItem> SmallItems => Set<SmallItem>();
}