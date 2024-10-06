using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Application.Dtos.Categories;

public class CreateCategoryDto
{
    public string Name { get; set; } = null!;
    public IFormFile Icon { get; set; } = null!;
    public int? ParentCategoryId { get; set; }

}
