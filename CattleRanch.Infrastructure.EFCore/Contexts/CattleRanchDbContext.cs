using CattleRanch.Application.Interfaces;
using CattleRanch.Core.Domain.Common;
using CattleRanch.Core.Domain.Entities;
using CattleRanch.Core.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CattleRanch.Infrastructure.EFCore.Contexts;
public class CattleRanchDbContext : DbContext, IApplicationDbContext
{
    public CattleRanchDbContext(DbContextOptions<CattleRanchDbContext> options) : base(options) { }

    public DbSet<Animal> Animals { get; set; }
    public DbSet<Breed> Breeds { get; set; }
    public DbSet<Farm> Farms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DiagnosisType>().HaveConversion<string>();
        configurationBuilder.Properties<Health>().HaveConversion<string>();
        configurationBuilder.Properties<HornStatus>().HaveConversion<string>();
        configurationBuilder.Properties<Origin>().HaveConversion<string>();
        configurationBuilder.Properties<Sex>().HaveConversion<string>();
        configurationBuilder.Properties<Status>().HaveConversion<string>();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        BeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void BeforeSave()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                ((AuditableEntity)entityEntry.Entity).CreatedOn = DateTime.UtcNow;
                ((AuditableEntity)entityEntry.Entity).CreatedBy = "system";
            }
            else
            {
                Entry((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedOn).IsModified = false;
                Entry((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;

                ((AuditableEntity)entityEntry.Entity).UpdatedOn = DateTime.UtcNow;
                ((AuditableEntity)entityEntry.Entity).UpdatedBy = "system";
            }
        }
    }
}
