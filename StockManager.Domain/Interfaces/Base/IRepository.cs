using System.Linq.Expressions;

namespace StockManager.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity? Get(Guid id);

        TEntity GetFirst();

        TEntity GetLast();

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);
    }
}