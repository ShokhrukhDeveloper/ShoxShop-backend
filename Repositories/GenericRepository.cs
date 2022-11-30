using System.Linq.Expressions;
using ShoxShop.Data;

namespace ShoxShop.Repositories;
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity :class
{
    private readonly ApplicationDbContext _dbContext;

    public GenericRepository(ApplicationDbContext context)
    {
        _dbContext=context;
    }
    public async ValueTask<TEntity> AddAsync(TEntity entity)
    {
        var entry= await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        =>_dbContext.Set<TEntity>().Where(expression);

    public TEntity? GetById(ulong id)
        =>  _dbContext.Set<TEntity>().Find(id);

    public IQueryable<TEntity> GetEntities()
        =>_dbContext.Set<TEntity>();

    public async ValueTask<TEntity> Remove(TEntity entity)
    {
        var entry = _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async ValueTask<TEntity> Update(TEntity entity)
    {
        var entry = _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }
}