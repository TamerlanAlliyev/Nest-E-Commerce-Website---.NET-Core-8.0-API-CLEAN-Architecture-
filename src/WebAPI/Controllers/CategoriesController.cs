
using Microsoft.AspNetCore.Mvc;
using Nest.Application.Dtos.Categories;
using Nest.Application.Services;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
    {
        try
        {
            var result = await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update( UpdateCategoryDto updateCategoryDto)
    {
        try
        {
            var result = await _categoryService.UpdateCategoryAsync( updateCategoryDto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }


    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
      
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            return Ok(await _categoryService.GetByIdCategoryAsync(id));
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await _categoryService.GetAllCategoriesAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}
