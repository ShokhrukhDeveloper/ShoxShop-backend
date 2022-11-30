using System.Linq.Expressions;

namespace ShoxShop.Repositories;
public interface IGenericRepository<TEntity> where TEntity:class
{
    TEntity? GetById(ulong id);
    IQueryable<TEntity> GetEntities{get;}
    IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> expression);
    ValueTask<TEntity> AddAsync(TEntity entity);
    ValueTask<TEntity> Remove(TEntity entity);
    ValueTask<TEntity> Update(TEntity entity);
}