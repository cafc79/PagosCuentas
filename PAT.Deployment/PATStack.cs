using PAT.Common.Extensions;
using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Storage;
using Pulumi.AzureNative.Storage.Inputs;
using Pulumi.AzureNative.Web;
using Pulumi.AzureNative.Web.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

class PATStack : Stack
{
    public PATStack()
    {
        var env = GetEnvironment();
        var allowedOrigins = "*";

        var resourceGroup = new ResourceGroup($"PAT-{env}-rg",
            ResourceArgs(env));
        var storageAccount = new StorageAccount(
            $"pat{env}sa",
            StorageArgs(resourceGroup.Name, $"pat{env}sa"));
        var appServicePlan = new AppServicePlan(
            $"PAT-{env}-windows-asp",
            ServicePlanArgs(resourceGroup.Name, $"PAT-{env}-windows-asp"));

        var outputBuilder = new StringBuilder();
        foreach (var functionName in GetFunctionNames(env))
        {
            var fileShare = CreateFileShare(
                resourceGroup.Name,
                storageAccount.Name,
                env,
                functionName);

            var app = CreateFunctionApp(
                appServicePlan.Id,
                resourceGroup.Name,
                storageAccount.Name,
                fileShare.Name,
                functionName,
                allowedOrigins,
                env);

            outputBuilder.AppendLine(GetFunctionEndpoint(app.DefaultHostName));
        }

        ResourceGroup = resourceGroup.Name;
    }

    [Output] public Output<string> ResourceGroup { get; set; }

    private static string GetEnvironment()
    {
        var env = Environment.GetEnvironmentVariable("PulumiEnvironment");
        var error = "Invalid environment, valid values are [qa, prod]";
        if (env is null)
            throw new ArgumentException(error, "PulumiEnvironment");
        else if (env != "qa" && env != "prod")
            throw new ArgumentException(error, "PulumiEnvironment");

        return env;
    }

    private static ResourceGroupArgs? ResourceArgs(string env)
        => new()
        {
            ResourceGroupName = $"PAT-{env}-rg"
        };

    private static StorageAccountArgs StorageArgs(
        Input<string> resourceGroupName,
        string storageAccountName)
    => new()
    {
        AccountName = storageAccountName,
        ResourceGroupName = resourceGroupName,
        Sku = new SkuArgs
        {
            Name = SkuName.Standard_LRS,
        },
        Kind = Kind.StorageV2,
    };

    private static AppServicePlanArgs ServicePlanArgs(
        Input<string> resourceGroupName,
        string servicePlanName)
    => new()
    {
        Name = servicePlanName,
        ResourceGroupName = resourceGroupName,
        Kind = "functionapp",
        Sku = new SkuDescriptionArgs
        {
            Tier = "Consumption",
            Name = "Y1",
            Size = "Y1",
            Family = "Y"
        },
        PerSiteScaling = false,
        MaximumElasticWorkerCount = 1,
        IsSpot = false,
        Reserved = false,
        IsXenon = false,
        HyperV = false,
        TargetWorkerCount = 0,
        TargetWorkerSizeId = 0,
    };

    private static FileShare CreateFileShare(
        Input<string> resourceGroupName,
        Input<string> storageAccountName,
        string environment,
        string functionName)
        => $"pat{environment}{functionName.ToLower().Replace("-", "")}"
            .MapV(name => new FileShare(name, new FileShareArgs
            {
                ShareName = name,
                AccountName = storageAccountName,
                EnabledProtocols = EnabledProtocols.SMB,
                ResourceGroupName = resourceGroupName
            }));

    private static WebApp CreateFunctionApp(
        Input<string> appServicePlanId,
        Input<string> resourceGroupName,
        Input<string> storageAccountName,
        Input<string> fileShareName,
        string functionName,
        string allowedOrigins,
        string environment)
        => new(functionName, new WebAppArgs
        {
            Name = functionName,
            Kind = "FunctionApp",
            ResourceGroupName = resourceGroupName,
            ServerFarmId = appServicePlanId,
            SiteConfig = new SiteConfigArgs
            {
                Cors = new CorsSettingsArgs
                {
                    AllowedOrigins = allowedOrigins,
                    SupportCredentials = false
                },
                AppSettings = new[]
                {
                    new NameValuePairArgs
                    {
                        Name = "AzureWebJobsDashboard",
                        Value = GetStorageConnectionString(resourceGroupName, storageAccountName)
                    },
                    new NameValuePairArgs{
                        Name = "AzureWebJobsStorage",
                        Value = GetStorageConnectionString(resourceGroupName, storageAccountName),
                    },
                    new NameValuePairArgs{
                        Name = "FUNCTIONS_EXTENSION_VERSION",
                        Value = "~4"
                    },
                    new NameValuePairArgs{
                        Name = "FUNCTIONS_WORKER_RUNTIME",
                        Value = "dotnet",
                    },
                    new NameValuePairArgs{
                        Name = "WEBSITE_CONTENTAZUREFILECONNECTIONSTRING",
                        Value = GetStorageConnectionString(resourceGroupName, storageAccountName),
                    },
                    new NameValuePairArgs{
                        Name = "WEBSITE_CONTENTSHARE",
                        Value = fileShareName,
                    },
                    new NameValuePairArgs{
                        Name = "WEBSITE_ENABLE_SYNC_UPDATE_SITE",
                        Value = "true",
                    },
                    new NameValuePairArgs
                    {
                        Name = "PATEnvironment",
                        Value = environment
                    }
                },
            },
        });

    private static IEnumerable<string> GetFunctionNames(string env)
        => new[]
        {
            $"PAT-{env}-UserManagement-Authentication",
          //  $"PAT-{env}-UserManagement-BillToPay",
            $"PAT-{env}-UserManagement-ChangeUserPassword",
            $"PAT-{env}-UserManagement-CreateRole",
            $"PAT-{env}-UserManagement-CreateUser",
            $"PAT-{env}-UserManagement-DeleteUser",
            $"PAT-{env}-UserManagement-EditUser",
            $"PAT-{env}-UserManagement-EditUserRole",
            $"PAT-{env}-UserManagement-GetRoles",
            $"PAT-{env}-UserManagement-GetUsers",
            $"PAT-{env}-UserManagement-RevokeTokenConfirmation",
            $"PAT-{env}-UserManagement-LockUser",
            $"PAT-{env}-UserManagement-SendPasswordResetLink",
            $"PAT-{env}-UserManagement-UnlockUser",
            $"PAT-{env}-UserManagement-RevokeTokenLogin",

            $"PAT-{env}-EgressManagement-BillToPay",
            $"PAT-{env}-EgressManagement-CompanyAmmounts",
            $"PAT-{env}-EgressManagement-PaymentHistory",
            $"PAT-{env}-EgressManagement-PaymentAuthorization",
            $"PAT-{env}-EgressManagement-ProcessAccountPayment",
            $"PAT-{env}-EgressManagement-ProcessAutorizationPayment",
            $"PAT-{env}-EgressManagement-ProcessPayment",
            $"PAT-{env}-EgressManagement-AmountsEgressManagement",
            $"PAT-{env}-EgressManagement-StatusIndicator",
            $"PAT-{env}-EgressManagement-ChangeIndicatorStatus",
            $"PAT-{env}-EgressManagement-ProcessRejectAutorizationPayment",
            $"PAT-{env}-EgressManagement-SchedulerBillPayment",

            $"PAT-{env}-PrivilegesManagement-Rol",
            $"PAT-{env}-Scheduler-SyncERP",
            
        };

    private static Output<string> GetStorageConnectionString(
        Input<string> resourceGroupName,
        Input<string> accountName)
        => ListStorageAccountKeys.Invoke(new ListStorageAccountKeysInvokeArgs
        {
            ResourceGroupName = resourceGroupName,
            AccountName = accountName
        }).MapV(sak => sak.Apply(keys =>
        {
            var primaryStorageKey = keys.Keys[0].Value;
            return Output.Format($"DefaultEndpointsProtocol=https;AccountName={accountName};AccountKey={primaryStorageKey}");
        }));

    private static string GetFunctionEndpoint(Input<string> hostName)
        => $"https://{hostName}/api/swagger/ui";
}
