using eshop.Catalog.Domain;
using eshop.Catalog.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace eshop.Catalog.Persistence.DbContexts
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            base.ChangeTracker.Entries<IEntity>()
                              .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified)
                              .ToList()
                              .ForEach(entty =>
                              {
                                  entty.Entity.DateModified = DateTime.Now;
                                  if (entty.State == EntityState.Added)
                                  {
                                      entty.Entity.DateCreated = DateTime.Now;
                                  }
                              });
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
