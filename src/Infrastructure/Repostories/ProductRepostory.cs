using Nest.Application.Repostories;
using Nest.Domain.Entity;
using Nest.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Infrastructure.Repostories;

public class ProductRepostory : BaseRepostory<Product>, IProductRepostory
{
    public ProductRepostory(ApplicationDbContext context) : base(context)
    {
    }
}
