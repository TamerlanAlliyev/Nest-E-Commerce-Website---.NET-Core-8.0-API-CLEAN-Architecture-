using Nest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Domain.Entity;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Images { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal? Discount { get; set; }
    public Category Category { get; set; } = null!;
    public int CategoryId { get; set; }
}
