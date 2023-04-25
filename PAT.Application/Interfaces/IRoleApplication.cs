using PAT.Application.Models;
using PAT.Application.Models.RoleManagement;

namespace PAT.Application.Interfaces;

public interface IRoleApplication
{
    Task<CreateRoleResponse> CreateRole(CreateRoleRequest request);
    Task<IEnumerable<GetRolesResponse>> GetRoles(GetRolesRequest request);
    Task<IEnumerable<RolPermissionResponse>> GetRolPermissions(RolPermissionRequest request);
    Task<IEnumerable<RolIndicatorResponse>> GetRolIndicator(RolIndicatorRequest request);
    Task<SpInsUpdtResponse> EnableRolIndicator(EnableRolIndicatorRequest request);
}

