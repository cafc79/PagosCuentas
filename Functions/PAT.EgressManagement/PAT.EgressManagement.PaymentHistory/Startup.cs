using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using PAT.EgressManagement.Common;
[assembly: FunctionsStartup(typeof(PAT.EgressManagement.PaymentHistory.Startup))]

namespace PAT.EgressManagement.PaymentHistory;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
        => builder.ConfigureUserManagement();

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        => builder.ConfigureAppConfiguration(base.ConfigureAppConfiguration);
}