using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Infrastructure.Presistance.Configurations.Common;

public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseAuditableEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(x=>x.Id).UseIdentityColumn().IsRequired(true);
        builder.Property(x=>x.IsDeleted).HasDefaultValue(false).IsRequired(true);
        builder.Property(x=>x.Created).HasColumnType("datetime").IsRequired(true);
        builder.Property(x=>x.CreatedBy).HasColumnType("nvarchar").HasMaxLength(100).IsRequired(true);
        builder.Property(x=>x.Modified).HasColumnType("datetime").IsRequired(false);
        builder.Property(x=>x.ModifiedBy).HasColumnType("nvarchar").HasMaxLength(100).IsRequired(false);
        builder.Property(x=>x.IP).HasColumnType("nvarchar(max)").IsRequired(true);
        builder.HasQueryFilter(x=>!x.IsDeleted);
    }
}
