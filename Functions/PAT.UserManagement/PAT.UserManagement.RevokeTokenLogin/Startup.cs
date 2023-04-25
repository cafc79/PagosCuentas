using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using PAT.UserManagement.Common;
[assembly: FunctionsStartup(typeof(PAT.UserManagement.RevokeTokenLogIn.Startup))]

namespace PAT.UserManagement.RevokeTokenLogIn;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
        => builder.ConfigureUserManagement();

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        => builder.ConfigureAppConfiguration(base.ConfigureAppConfiguration);
}