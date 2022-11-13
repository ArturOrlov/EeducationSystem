using EducationSystem.Context;
using EducationSystem.Entities.Base;
using EducationSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly EducationSystemDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(EducationSystemDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync();
    }

    public async Task<List<TEntity>> GetRangeAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }
    
    public async Task<int> CountAllAsync()
    {
        return await _dbSet.CountAsync();
    }

    public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate, BasePagination pagination)
    {
        return _dbSet.Where(predicate)
            .Skip(pagination.Skip)
            .Take(pagination.Take)
            .ToList();
    }

    public async Task CreateAsync(TEntity entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}