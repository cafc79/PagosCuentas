using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using PAT.Common.Extensions;
using PAT.Infrastructure.Common;
using PAT.Infrastructure.Context;

namespace JDA.Infrastructure.Context;

public class PATContextFactory : IDesignTimeDbContextFactory<PATContext>
{
    public PATContext CreateDbContext(string[] args)
        => new ServiceCollection()
            .AddDbContext<PATContext>(
                // llenar al momento de aplicar el migration
                // valores válidos [qa,prod]
                b => Configuration.ConfigureSqlServer(b, "qa"))
            .BuildServiceProvider()
            .GetService<PATContext>()!;
}