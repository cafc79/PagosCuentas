using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PAT.Common.Models;

using System.Linq.Expressions;
namespace PAT.Common.Interfaces;

public interface ISqlRepository<TContext> where TContext : DbContext
{
    Task<int> CreateAsync<TEntity>(TEntity entity) where TEntity : PATEntity;
    Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : PATEntity;
    Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : PATEntity;
    Task<List<TEntity>> QueryAsync<TEntity>(
        Expression<Func<TEntity, bool>> predicate) where TEntity : PATEntity;
    Task<List<TEntity>> QueryViewAsync<TEntity>(
     Expression<Func<TEntity, bool>> predicate) where TEntity : class;
    Task<int> InsertUpdateByStore(string nombreStored, IEnumerable<SqlParameter> parameters);
    Task<IEnumerable<TEntity>> InsertUpdateByStore<TEntity>(string nombreStored, IEnumerable<SqlParameter> parameters) where TEntity : class;

}