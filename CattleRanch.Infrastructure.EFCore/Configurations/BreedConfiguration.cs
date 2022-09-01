using CattleRanch.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CattleRanch.Infrastructure.EFCore.Configurations;
public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable("Breeds");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name).IsRequired().HasMaxLength(20);
        builder.Navigation(b => b.Animals).UsePropertyAccessMode(PropertyAccessMode.Field).AutoInclude();
        builder.HasIndex(ix => ix.Name).IsUnique();
    }
}
