using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PAT.Infrastructure.Common;

using static Directory;
using static Path;

internal static class Configuration
{
    internal static void ConfigureSqlServer(
        DbContextOptionsBuilder builder,
        string env)
        => builder.UseSqlServer(GetConnectionString(env));

    private static string GetConnectionString(
        string env)
        => new ConfigurationBuilder()
            .AddJsonFile($"appsettings.{env}.json")
            .SetBasePath(GetBasePath())
            .Build()
            .GetConnectionString("PAT");

    private static string GetBasePath()
        => Combine(
            GetParent(GetCurrentDirectory())!.FullName,
            "Functions",
            "PAT.UserManagement",
            "PAT.UserManagement.Common");
}