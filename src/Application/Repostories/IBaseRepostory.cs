using Nest.Domain.Common;
using Nest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Application.Repostories;

public interface IBaseRepostory<TEntity> where TEntity : BaseAuditableEntity
{
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
    Task<TEntity> GetAsync(int id);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, params string[] includes);
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes);

}
