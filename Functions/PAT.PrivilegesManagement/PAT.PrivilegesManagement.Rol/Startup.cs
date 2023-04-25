using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using PAT.PrivilegesManagement.Common;
[assembly: FunctionsStartup(typeof(PAT.PrivilegesManagement.Rol.Startup))]

namespace PAT.PrivilegesManagement.Rol;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
        => builder.ConfigureUserManagement();

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        => builder.ConfigureAppConfiguration(base.ConfigureAppConfiguration);
}