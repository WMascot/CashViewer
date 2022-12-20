using CashViewer_backend.DAL.Context;
using CashViewer_backend.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CashViewer_backend.DAL.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _set;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _set = db.Set<T>();
        }
        public IQueryable<T> Items => _set;

        public T Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _db.Entry(entity).State = EntityState.Added;
            _db.SaveChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _db.Entry(entity).State = EntityState.Added;
            await _db.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity;
        }

        public T Get(int id) => Items.SingleOrDefault(x => x.Id == id);

        public async Task<T> GetAsync(int id, CancellationToken cancellationToken = default) =>
            await Items.SingleOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

        public void Remove(int id)
        {
            var item = _set.Local.SingleOrDefault(x => x.Id == id) ?? new T { Id = id };
            _db.Remove(item);
            _db.SaveChanges();
        }

        public async Task RemoveAsync(int id, CancellationToken cancellationToken = default)
        {
            var item = _set.Local.SingleOrDefault(x => x.Id == id) ?? new T { Id = id };
            _db.Remove(item);
            await _db.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
