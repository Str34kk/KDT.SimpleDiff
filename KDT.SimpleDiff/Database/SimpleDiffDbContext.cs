using KDT.SimpleDiff.Entities;
using Microsoft.EntityFrameworkCore;

namespace KDT.SimpleDiff.Database;

public class SimpleDiffDbContext : DbContext
{
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: @"Data Source=C:\Users\KonDzik\source\repos\KonDzikToolbox\kdt.sqlite;");
    }
    
    public DbSet<Diff> Diffs => Set<Diff>();
}