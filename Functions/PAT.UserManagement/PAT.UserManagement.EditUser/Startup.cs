using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using PAT.UserManagement.Common;

[assembly: FunctionsStartup(typeof(PAT.UserManagement.EditUser.Startup))]

namespace PAT.UserManagement.EditUser;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
        => builder.ConfigureUserManagement();

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        => builder.ConfigureAppConfiguration(base.ConfigureAppConfiguration);
}