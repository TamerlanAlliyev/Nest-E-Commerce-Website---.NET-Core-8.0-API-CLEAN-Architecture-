using AutoMapper;
using Nest.Application.Dtos.Categories;
using Nest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Application.Common.Mapping;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Category,CategoryDto>().ReverseMap();
        CreateMap<Category,CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
    }
}
