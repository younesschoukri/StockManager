using System.Linq.Expressions;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly StockManagerDbContext context;

        public Repository(StockManagerDbContext context)
        {
            this.context = context;
        }

        public TEntity? Get(Guid id) => context.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll() => context.Set<TEntity>().ToList();

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => context.Set<TEntity>().Where(predicate).ToList();

        public void Add(TEntity entity) => context.Set<TEntity>().Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) => context.Set<TEntity>().AddRange(entities);

        public void Remove(TEntity entity) => context.Set<TEntity>().Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) => context.Set<TEntity>().RemoveRange(entities);

        public TEntity GetFirst() => context.Set<TEntity>().First();

        public TEntity GetLast() => context.Set<TEntity>().Last();
    }
}