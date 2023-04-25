using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace PAT.Common.Utils;

public static class EnvironmentUtils
{
    public static string GetPATEnvironment(
        FunctionsHostBuilderContext context)
    {
        var env = context.Configuration.GetValue<string>("PATEnvironment");

        if (env is null)
            env = Environment.GetEnvironmentVariable("PATEnvironment");

        var error = "Invalid environment variable PATEnvironment, valid values are [qa, prod]";
        if (env is null)
            throw new ApplicationException(error);
        else if (env != "qa" && env != "prod")
            throw new ApplicationException(error);

        return env;
    }
}
