using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IRepositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TEntity> GetByIdAsync(int id);
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<TEntity>> GetRangeAsync();
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<int> CountAllAsync();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="pagination"></param>
    /// <returns></returns>
    IEnumerable<TEntity> Get(Func<TEntity, bool> predicate, BasePagination pagination);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task CreateAsync(TEntity entity);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task UpdateAsync(TEntity entity);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task DeleteAsync(TEntity entity);
}