using Nest.Domain.Common;
using System;
using System.Collections.Generic;

namespace Nest.Domain.Entity
{
    public class Category : BaseAuditableEntity
    {
        public Category()
        {
            SubCategories = new HashSet<Category>();
        }

        public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;

        public Category? ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }

        public List<Product> Products { get; set; } = new List<Product>(); 
        public ICollection<Category>? SubCategories { get; set; } 
    }
}
