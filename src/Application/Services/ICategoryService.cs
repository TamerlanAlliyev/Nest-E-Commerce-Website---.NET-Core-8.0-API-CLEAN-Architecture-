using Nest.Application.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Application.Services;

public interface ICategoryService
{
    Task<CreateCategoryDto> CreateCategoryAsync(CreateCategoryDto category);
    Task<UpdateCategoryDto> UpdateCategoryAsync(UpdateCategoryDto category);
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto> GetByIdCategoryAsync(int id);
    Task DeleteCategoryAsync(int id);
}
