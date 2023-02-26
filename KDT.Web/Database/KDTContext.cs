using KDT.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace KDT.Web.Database;

public class KdtContext : DbContext
{
    public KdtContext(DbContextOptions<KdtContext> options)
        : base(options) { }

    public DbSet<SmallItem> SmallItems => Set<SmallItem>();
}