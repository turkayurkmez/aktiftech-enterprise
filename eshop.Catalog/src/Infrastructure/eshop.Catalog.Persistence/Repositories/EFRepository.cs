using eshop.Catalog.Application.Contracts.Persistence;
using eshop.Catalog.Domain.Common;
using eshop.Catalog.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace eshop.Catalog.Persistence.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : IEntity
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
            return await catalogDbContext.Set<T>().AsN.ToListAsync();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
