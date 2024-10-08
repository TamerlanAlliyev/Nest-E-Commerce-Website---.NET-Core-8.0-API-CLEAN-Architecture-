﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest.Application.Repostories;
using Nest.Application.Services;
using Nest.Infrastructure.Persistance;
using Nest.Infrastructure.Repostories;
using Nest.Infrastructure.Services;

namespace Nest.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("mssql")));

            services.AddScoped<ICategoryRepostory, CategoryRepostory>();
            services.AddScoped<IProductRepostory, ProductRepostory>();
            services.AddScoped<ICategoryService, CategoryManager>();

            return services;
        }
    }
}
