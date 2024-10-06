using Microsoft.EntityFrameworkCore;
using Nest.Application.Repostories;
using Nest.Domain.Common;
using Nest.Domain.Entity;
using Nest.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Infrastructure.Repostories;

public class BaseRepostory<TEntity> : IBaseRepostory<TEntity> where TEntity : BaseAuditableEntity
{
    private readonly ApplicationDbContext _context;

    public BaseRepostory(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        entity!.IsDeleted = true;
        await _context.SaveChangesAsync();
    }
    public async Task<TEntity> GetAsync(int id)
    {
        return await _context.Set<TEntity>().FirstAsync(entity => entity.Id == id);
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, params string[] includes)
    {
        return expression != null ? 
            await _context.Set<TEntity>().FirstOrDefaultAsync(expression):
            await _context.Set<TEntity>().Where(expression).FirstOrDefaultAsync(expression);
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression, params string[] includes)
    {
        var entity = _context.Set<TEntity>().AsQueryable();
        foreach (var type in includes)
        {
          entity = entity.Include(type);
        }

        return expression != null ?
              await entity.ToListAsync() :
              await entity.Where(expression!).ToListAsync();
    }
}
