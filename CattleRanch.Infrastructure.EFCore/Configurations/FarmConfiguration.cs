using CattleRanch.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CattleRanch.Infrastructure.EFCore.Configurations;
public class FarmConfiguration : IEntityTypeConfiguration<Farm>
{
    public void Configure(EntityTypeBuilder<Farm> builder)
    {
        builder.ToTable("Farms");
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Code).IsRequired().HasMaxLength(3);
        builder.Property(f => f.Name).IsRequired().HasMaxLength(150);
        builder.Property(f => f.Address).IsRequired().HasMaxLength(150);
        builder.Property(f => f.Phone).IsRequired().HasMaxLength(15);
        builder.Navigation(f => f.Animals).UsePropertyAccessMode(PropertyAccessMode.Field).AutoInclude();
        builder.HasIndex(ix => ix.Code).IsUnique();
    }
}
