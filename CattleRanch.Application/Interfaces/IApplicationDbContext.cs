using CattleRanch.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CattleRanch.Application.Interfaces;
public interface IApplicationDbContext
{
    DbSet<Animal> Animals { get; set; }
    DbSet<Breed> Breeds { get; set; }
    DbSet<Farm> Farms { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
