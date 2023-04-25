﻿using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using PAT.UserManagement.Common;

[assembly: FunctionsStartup(typeof(PAT.UserManagement.CreateUser.Startup))]

namespace PAT.UserManagement.CreateUser;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
        => builder.ConfigureUserManagement();

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        => builder.ConfigureAppConfiguration(base.ConfigureAppConfiguration);
}