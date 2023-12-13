namespace Lecommerce.Domain.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
