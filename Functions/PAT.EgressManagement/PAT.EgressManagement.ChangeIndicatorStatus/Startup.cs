using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using PAT.EgressManagement.Common;
[assembly: FunctionsStartup(typeof(PAT.EgressManagement.ChangeIndicatorStatusFunction.Startup))]

namespace PAT.EgressManagement.ChangeIndicatorStatusFunction;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
        => builder.ConfigureUserManagement();

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        => builder.ConfigureAppConfiguration(base.ConfigureAppConfiguration);
}