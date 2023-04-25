using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using PAT.EgressManagement.Common;
[assembly: FunctionsStartup(typeof(PAT.EgressManagement.AmountsEgressManagement.Startup))]

namespace PAT.EgressManagement.AmountsEgressManagement;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
        => builder.ConfigureUserManagement();

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        => builder.ConfigureAppConfiguration(base.ConfigureAppConfiguration);
}