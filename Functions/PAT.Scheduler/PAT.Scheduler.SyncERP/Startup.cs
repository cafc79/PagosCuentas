using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using PAT.Scheduler.Common;
[assembly: FunctionsStartup(typeof(PAT.Scheduler.SyncERP.Startup))]

namespace PAT.Scheduler.SyncERP;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
        => builder.ConfigureUserManagement();

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        => builder.ConfigureAppConfiguration(base.ConfigureAppConfiguration);
}