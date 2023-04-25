using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using PAT.Infrastructure.Common;

namespace PAT.Infrastructure.Context;

public class ApplicationIdentityContextFactory
    : IDesignTimeDbContextFactory<ApplicationIdentityContext>
{
    public ApplicationIdentityContext CreateDbContext(string[] args)
        => new ServiceCollection()
            .AddDbContext<ApplicationIdentityContext>(
                // llenar al momento de aplicar el migration
                // valores válidos [qa,prod]
                b => Configuration.ConfigureSqlServer(b, ""))
            .BuildServiceProvider()
            .GetService<ApplicationIdentityContext>()!;
}