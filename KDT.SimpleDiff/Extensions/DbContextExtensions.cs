using KDT.SimpleDiff.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace KDT.SimpleDiff.Extensions;

public static class DbContextExtensions
{
    public static async Task<int> VersionedSaveChangesAsync(this DbContext dbContext)
    {
        var affectedEntities = dbContext.ChangeTracker.Entries()
            .Where(e => e.Entity.GetType().GetCustomAttributes(typeof(VersionedAttribute), true).Any())
            .ToList();

        var result = await dbContext.SaveChangesAsync();
        LogAffectedEntities(affectedEntities);
        return result;
    }
    
    private static void LogAffectedEntities(IEnumerable<EntityEntry> affectedEntities)
    {
        foreach (var entry in affectedEntities)
        {
            var idProperty = entry.Property("Id");
            var idValue = idProperty?.CurrentValue;
            Console.WriteLine($"Entity {entry.Entity.GetType().Name} with state {entry.State} and ID {idValue} is affected.");
        }
    }
}