using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nest.Domain.Entity;
using Nest.Infrastructure.Presistance.Configurations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Infrastructure.Presistance.Configurations;

public class ProductConfiguration : BaseConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {

        builder.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(150).IsRequired(true);
        builder.Property(x => x.Description).HasColumnType("nvarchar").HasMaxLength(500).IsRequired(true);
        builder.Property(x => x.Images).HasColumnType("nvarchar").HasMaxLength(500).IsRequired(true);
        builder.Property(x => x.Discount).HasColumnType("decimal(18,2)").IsRequired(true);
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired(true);

        builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);

        base.Configure(builder);
    }
}
