using System.Reflection;

namespace Catalog.Data;

public class CatalogDbContext : DbContext
{
  public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
  {
  }

  DbSet<Product> Products => Set<Product>();

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.HasDefaultSchema("Catalog");
    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    base.OnModelCreating(builder);
  }

}
