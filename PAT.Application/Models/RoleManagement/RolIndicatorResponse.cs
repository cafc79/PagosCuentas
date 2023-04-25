namespace PAT.Application.Models.RoleManagement
{
    public readonly record struct RolIndicatorResponse
     (
        string RoleId,
         string RolName,
         bool Indicator
    );
}
