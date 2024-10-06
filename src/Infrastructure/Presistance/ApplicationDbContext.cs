using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Nest.Application.Common.Interfaces;
using Nest.Domain.Common;
using Nest.Domain.Entity;
using System.Reflection;
using Microsoft.AspNetCore.Http;


namespace Nest.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IHttpContextAccessor _accessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
                                    IHttpContextAccessor accessor) : base(options)
        {
            _accessor = accessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseAuditableEntity>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _accessor.HttpContext?.User?.Identity?.Name ?? "unknownUser";
                        entry.Entity.Created = DateTime.UtcNow.AddHours(4);
                        entry.Entity.IP = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "unknownIP";
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _accessor.HttpContext?.User?.Identity?.Name ?? "unknownUser";
                        entry.Entity.Modified = DateTime.UtcNow.AddHours(4);
                        entry.Entity.IP = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "unknownIP";
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
