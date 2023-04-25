
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PAT.Common.Interfaces;
using PAT.Common.Models;
using PAT.Models.Database.Stores;
using System.Linq.Expressions;

namespace PAT.Infrastructure.Services;

public class SqlRepository<TContext> : ISqlRepository<TContext> where TContext : DbContext
{
    private readonly DbContext _context;

    public SqlRepository(DbContext context)
        => _context = context;

    public async Task<int> CreateAsync<TEntity>(TEntity entity) where TEntity : PATEntity
    {
        entity.FechaCreacion = DateTime.UtcNow;
        entity.FechaActualizacion = DateTime.UtcNow;
        entity.Eliminado = false;
        _context.Set<TEntity>().Add(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : PATEntity
    {
        entity.Eliminado = true;
        return await UpdateAsync(entity);
    }

    public async Task<List<TEntity>> QueryAsync<TEntity>(
        Expression<Func<TEntity, bool>> predicate)
    where TEntity : PATEntity
        => await _context.Set<TEntity>()
            .Where(r => !r.Eliminado)
            .Where(predicate)
            .AsNoTracking()
            .ToListAsync();
    public async Task<List<TEntity>> QueryViewAsync<TEntity>(
          Expression<Func<TEntity, bool>> predicate)
      where TEntity : class
          => await _context.Set<TEntity>()
              .Where(predicate)
              .AsNoTracking()
              .ToListAsync();
    public async Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : PATEntity
    {
        entity.FechaActualizacion = DateTime.UtcNow;

        var dbModel = _context.Find<TEntity>(entity.Id);
        if (dbModel is not null && !dbModel.Eliminado)
        {
            _context.Entry(dbModel).State = EntityState.Detached;
            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }
        return 0;
    }
    public async Task<int> InsertUpdateByStore(string nombreStored, IEnumerable<SqlParameter> parameters)
    {
        var variables = string.Join(",",parameters.Select(d=>d.ParameterName));
        var res= await _context.Database.ExecuteSqlRawAsync(string.Format("EXEC {0} {1}", nombreStored, variables), parameters: parameters);
        return res;
    }
    public async Task<IEnumerable<TEntity>> InsertUpdateByStore<TEntity>(string nombreStored, IEnumerable<SqlParameter> parameters) where TEntity:class
    {
        var variables = string.Join(",", parameters.Select(d => d.ParameterName));
        var res = await _context.Set<TEntity>().FromSqlRaw(string.Format("EXEC {0} {1}", nombreStored, variables), parameters: parameters.ToArray()).ToListAsync() ;
        return res;
    }
}
