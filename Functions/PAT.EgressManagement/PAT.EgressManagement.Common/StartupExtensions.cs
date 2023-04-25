namespace PAT.EgressManagement.Common
{
    using Microsoft.Azure.Functions.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PAT.Application.Interfaces;
    using PAT.Application.Services;
    using PAT.Common.Extensions;
    using PAT.Common.Interfaces;
    using PAT.Domain.Interfaces;
    using PAT.Domain.Services;
    using PAT.Infrastructure.Context;
    using PAT.Infrastructure.Services;
    using PAT.Models.Configuration;
    using PAT.Provider;
    using PAT.Provider.Interafaces;
    using PAT.Provider.Services;
    using Serilog;
    using Serilog.Events;
    using Serilog.Sinks.MSSqlServer;
    using static PAT.Common.Utils.EnvironmentUtils;

    public static class StartupExtensions
    {
        public static void ConfigureAppConfiguration(
            this IFunctionsConfigurationBuilder builder,
            Action<IFunctionsConfigurationBuilder> baseConfiguration)
        {
            var context = builder.GetContext();
            var env = GetPATEnvironment(context);

            baseConfiguration(builder);
            var config = Path.Combine(
                context.ApplicationRootPath,
                $"appsettings.{env}.json");

            builder.ConfigurationBuilder
               .SetBasePath(context.ApplicationRootPath)
               .AddJsonFile(config, optional: false, reloadOnChange: false)
               .Build();
        }

        public static void ConfigureUserManagement(this IFunctionsHostBuilder builder)
        {
            var context = builder.GetContext();
            var cs = context.Configuration.GetConnectionString("PAT");

            builder.Services
                .ConfigureLogger(cs)
                .AddApplicationServices()
                .AddPATDatabase(cs)
                //.AddIdentityConfiguration(cs)
                .AddSettings<AuthSettings>(nameof(AuthSettings))
                .AddSettings<EmailSettings>(nameof(EmailSettings));
        }

        private static IServiceCollection ConfigureLogger(
            this IServiceCollection services,
            string connectionString)
            => services.AddLogging(lb => lb.AddSerilog(new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("System", LogEventLevel.Error)
                .WriteTo
                .MSSqlServer(
                    connectionString,
                    new MSSqlServerSinkOptions { TableName = "Log" })
                .CreateLogger()));

        private static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
            => services
          
                .AddTransient<IEgressApplication, EgressApplication>()
                .AddTransient<IEgressService, EgressService>()
                 .AddTransient<ISyncERPService, SyncERPService>()
                 .AddTransient<IEmailService, EmailService>()
                .AddTransient<ISqlRepository<DbContext>, SqlRepository<DbContext>>();

        private static IServiceCollection AddSettings<TOptions>( 
            this IServiceCollection services,
            string section)
            where TOptions : class
            => services.Execute(s => s.AddOptions<TOptions>()
                .Configure<IConfiguration>((s, c) => c
                    .GetSection(section).Bind(s)));

        //private static IServiceCollection AddIdentityConfiguration(
        //    this IServiceCollection services,
        //    string connectionString)
        //    => services.Execute(s => s
        //        .AddDbContext<ApplicationIdentityContext>(o
        //            => ConfigureIdentityContext(o, connectionString))
        //        .AddIdentityCore<PATUser>(ConfigureIdentityOptions)
        //        .AddUserManager<UserManager<PATUser>>()
        //        .AddRoles<IdentityRole>()
        //        .AddSignInManager<SignInManager<PATUser>>()
        //        .AddEntityFrameworkStores<ApplicationIdentityContext>()
        //        .AddTokenProvider<DataProtectorTokenProvider<PATUser>>(TokenOptions.DefaultProvider));

        private static void ConfigureIdentityContext(
            DbContextOptionsBuilder options,
            string connectionString)
            => options.UseSqlServer(connectionString);

        private static IServiceCollection AddPATDatabase(
            this IServiceCollection services,
            string connectionString)
            => services
                .AddPATContext(connectionString);

        //private static void ConfigureIdentityOptions(IdentityOptions options)
        //{
        //    options.SignIn.RequireConfirmedEmail = true;
        //    options.User.RequireUniqueEmail = true;
        //}

        private static IServiceCollection AddPATContext(
                this IServiceCollection services,
                string connectionString)
            => services.AddDbContext<DbContext, PATContext>(cfg =>
                cfg.UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(1800)));
    }
}