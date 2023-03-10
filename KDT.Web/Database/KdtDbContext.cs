using KDT.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace KDT.Web.Database;

public class KdtDbContext : DbContext
{
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "KDT");
    }
    
    public DbSet<SmallItem> SmallItems => Set<SmallItem>();
}