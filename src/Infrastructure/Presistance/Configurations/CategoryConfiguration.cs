using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nest.Domain.Entity;
using Nest.Infrastructure.Presistance.Configurations.Common;

namespace Nest.Infrastructure.Presistance.Configurations
{
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(150)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.Icon)
                 .HasMaxLength(150)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.HasOne(x => x.ParentCategory)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasMany(x => x.SubCategories)
                .WithOne(x => x.ParentCategory)
                .HasForeignKey(x => x.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict); 

            base.Configure(builder);
        }
    }
}
