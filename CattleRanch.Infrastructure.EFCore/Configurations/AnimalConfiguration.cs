using CattleRanch.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CattleRanch.Infrastructure.EFCore.Configurations;
public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.ToTable("Animals");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Code).IsRequired().HasMaxLength(15);
        builder.Property(x => x.EarTag).HasMaxLength(15);
        builder.Property(x => x.Name).HasMaxLength(20);
        builder.Property(x => x.Colour).HasMaxLength(20);
        builder.Property(x => x.Brand).HasMaxLength(3);
        builder.Property(x => x.Sex).HasMaxLength(10);
        builder.Property(x => x.Origin).HasMaxLength(10);
        builder.Property(x => x.Status).HasMaxLength(10);
        builder.Property(x => x.Category).HasMaxLength(20);
        builder.Property(x => x.DOB).HasColumnType("date");
        builder.Property(x => x.BirthWeight).HasPrecision(9, 2);
        builder.Property(x => x.ArrivalDate).HasColumnType("date");
        builder.Property(x => x.IncomeWeight).HasPrecision(9, 2);
        builder.Property(x => x.ImagePath).HasMaxLength(255);
        builder.Property(x => x.Remark).HasMaxLength(1500);
        builder.HasOne(a => a.Breed).WithMany(b => b.Animals).HasForeignKey(fk => fk.BreedId);

        builder.HasOne(a => a.Farm).WithMany(f => f.Animals).HasForeignKey(fk => fk.FarmId);

        builder.HasMany(a => a.DamPups).WithOne(a => a.Dam).HasForeignKey(fk => fk.DamId).OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(a => a.SirePups).WithOne(a => a.Sire).HasForeignKey(fk => fk.SireId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(a => a.Code).IsUnique();
    }
}
