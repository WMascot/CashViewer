namespace CashViewer_backend.DAL.Interfaces
{
    public interface IRepository<T> where T: class, IEntity, new()
    {
        IQueryable<T> Items { get; }
        T Get(int id);
        Task<T> GetAsync(int id, CancellationToken cancellationToken = default);
        T Add(T entity);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        void Remove(int id);
        Task RemoveAsync(int id, CancellationToken cancellationToken = default);
    }
}
