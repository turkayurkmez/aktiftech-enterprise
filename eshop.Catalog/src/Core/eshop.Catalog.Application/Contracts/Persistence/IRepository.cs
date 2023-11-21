using eshop.Catalog.Domain.Common;

namespace eshop.Catalog.Application.Contracts.Persistence
{
    public interface IRepository<T> where T : IEntity, new()
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIdAsync(int id);


    }
}
