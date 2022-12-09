using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShoxShop.Data;

namespace ShoxShop.Repositories;
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity :class
{
    private readonly ApplicationDbContext _dbContext;
    private DbSet<TEntity> _dbSet => _dbContext.Set<TEntity>();

    public GenericRepository(ApplicationDbContext context)
    {
        _dbContext=context;
    }
    public async ValueTask<TEntity> AddAsync(TEntity entity)
    {
        var entry= await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        =>_dbSet.Where(expression);

    public TEntity? GetById(ulong id)
        =>  _dbSet.Find(id);

    public IQueryable<TEntity> GetEntities
        =>_dbSet;

    public async ValueTask<TEntity> Remove(TEntity entity)
    {
        var entry = _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async ValueTask<TEntity> Update(TEntity entity)
    {
        var entry = _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }
}