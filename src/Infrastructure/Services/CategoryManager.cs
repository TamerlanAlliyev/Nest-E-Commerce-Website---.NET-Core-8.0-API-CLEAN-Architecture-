using AutoMapper;
using Microsoft.Extensions.Hosting;
using Nest.Application.Common.Mapping;
using Nest.Application.Dtos.Categories;
using Nest.Application.Repostories;
using Nest.Application.Services;
using Nest.Domain.Entity;
using Nest.Infrastructure.Extensions;
using Nest.Infrastructure.Repostories;

namespace Nest.Infrastructure.Services;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepostory _categoryRepostory;
    private readonly IHostEnvironment _environment;
    private readonly IMapper _mapping;
    public CategoryManager(ICategoryRepostory categoryRepostory, IHostEnvironment environment, IMapper mapping)
    {
        _categoryRepostory = categoryRepostory;
        _environment = environment;
        _mapping = mapping;
    }

    public async Task<CreateCategoryDto> CreateCategoryAsync(CreateCategoryDto createdCategory)
    {
        var fileName = await createdCategory.Icon.SaveFileAsync(_environment.ContentRootPath, Path.Combine("wwwroot", "client", "images", "settings", "categories"));
        Category category = _mapping.Map<Category>(createdCategory);
        category.Icon = fileName;
        await _categoryRepostory.CreateAsync(category);

        return createdCategory;
    }

    public async Task DeleteCategoryAsync(int id)
    {
        await _categoryRepostory.DeleteAsync(id);
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        IEnumerable<Category> categories = await _categoryRepostory.GetAllAsync(x => x.ParentCategoryId == null, nameof(Category.SubCategories));
        return _mapping.Map<IEnumerable<CategoryDto>>(categories);
    }
    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesIncludeAsync()
    {
        IEnumerable<Category> categories = await _categoryRepostory.GetAllAsync(x=>x.ParentCategoryId==null,nameof(Product.Images), nameof(Category.SubCategories));
        return _mapping.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetByIdCategoryAsync(int id)
    {
        Category category = await _categoryRepostory.GetAsync(id);
        return _mapping.Map<CategoryDto>(category);
    }

    public async Task<UpdateCategoryDto> UpdateCategoryAsync(UpdateCategoryDto updateCategory)
    {
        var existingCategory = await _categoryRepostory.GetAsync(updateCategory.Id);
        if (existingCategory == null)
            throw new Exception("Category Not Found");

        existingCategory.Name = updateCategory.Name;
        existingCategory.ParentCategoryId = updateCategory.ParentCategoryId;

        if (updateCategory.Icon != null)
        {
            FileExtensions.DeleteFile(_environment.ContentRootPath, Path.Combine("wwwroot", "client", "images", "settings", "categories"), existingCategory.Icon);

            var fileName = await updateCategory.Icon.SaveFileAsync(_environment.ContentRootPath, Path.Combine("wwwroot", "client", "images", "settings", "categories"));
            existingCategory.Icon = fileName;
        }

        await _categoryRepostory.UpdateAsync(existingCategory);

        return updateCategory;
    }

}
