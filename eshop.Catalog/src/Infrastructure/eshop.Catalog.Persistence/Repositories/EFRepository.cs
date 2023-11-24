using eshop.Catalog.Application.Contracts.Persistence;
using eshop.Catalog.Domain.Common;
using eshop.Catalog.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace eshop.Catalog.Persistence.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected readonly CatalogDbContext catalogDbContext;

        public EFRepository(CatalogDbContext catalogDbContext)
        {
            this.catalogDbContext = catalogDbContext;
        }

        public async Task CreateAsync(T entity)
        {
            await catalogDbContext.AddAsync(entity);
            await catalogDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            catalogDbContext.Remove(entity);
            await catalogDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await catalogDbContext.Set<T>().AsNoTracking().ToListAsync();


        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await catalogDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            catalogDbContext.Update(entity);
            catalogDbContext.Entry(entity).State = EntityState.Modified;
            await catalogDbContext.SaveChangesAsync();
        }
    }
}
