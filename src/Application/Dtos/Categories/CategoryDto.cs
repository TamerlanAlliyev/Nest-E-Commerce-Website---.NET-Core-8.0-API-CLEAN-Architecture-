using Microsoft.AspNetCore.Http;
using Nest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Application.Dtos.Categories;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public int? ParentCategoryId { get; set; }
    public ICollection<CategoryDto>?  SubCategories{ get; set; }
}
