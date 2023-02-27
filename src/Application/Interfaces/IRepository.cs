namespace Application.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(TKey id);
        Task<List<TEntity>> GetAllAsync();
    }
}