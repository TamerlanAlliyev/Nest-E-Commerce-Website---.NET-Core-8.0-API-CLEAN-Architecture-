using Nest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Application.Repostories;

public interface ICategoryRepostory
{
    Task<Category> GetAsync(int id);
    Task<List<Category>> GetAllAsync();
    Task CreateAsync(Category category);
    Task UpdateAsync( Category category);
    Task DeleteAsync(int id);
}
