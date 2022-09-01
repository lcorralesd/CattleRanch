using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CattleRanch.Infrastructure.EFCore.Contexts;
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<CattleRanchDbContext>
{
    // Add-Migration InitialCreate -p CattleRanch.Infrastructure.EFCore -s CattleRanch.Infrastructure.EFCore -c CattleRanchDbContext
    // Update-Database -p CattleRanch.Infrastructure.EFCore -s CattleRanch.Infrastructure.EFCore

    // Remove-Migration -p CattleRanch.Infrastructure.EFCore -s CattleRanch.Infrastructure.EFCore -c CattleRanchDbContext 
    // Drop-Database -p CattleRanch.Infrastructure.EFCore -s CattleRanch.Infrastructure.EFCore

    public CattleRanchDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CattleRanchDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CattleRanch;MultipleActiveResultSets=True");

        return new CattleRanchDbContext(optionsBuilder.Options);
    }
}
