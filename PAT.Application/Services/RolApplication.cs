using PAT.Application.Interfaces;
using PAT.Application.Models;
using PAT.Application.Models.RoleManagement;
using PAT.Domain.Interfaces;

namespace PAT.Application.Services
{
    public class RolApplication : IRoleApplication
    {
        private readonly IRoleService _rolService;

        public RolApplication(IRoleService rolService)
            => _rolService = rolService;

        public async Task<CreateRoleResponse> CreateRole(CreateRoleRequest request)
        {
            var result = await _rolService.CreateRole(request.RoleName);
            return new(result.Success, result.Errors);
        }
        public async Task<IEnumerable<GetRolesResponse>> GetRoles(GetRolesRequest request)
        {
            var result = await _rolService.GetRoles();
            return result.Select(r => new GetRolesResponse(r.RoleId, r.RoleName,r.NormalizedName));
        }
        public async Task<IEnumerable<RolPermissionResponse>> GetRolPermissions(RolPermissionRequest request)
        {
            var result = await _rolService.GetRolPermissions();
            return result.Select(r => new RolPermissionResponse(r.RoleId, r.RolName, r.PermissionId,r.PermissionName,r.Status));
        }
        public async Task<IEnumerable<RolIndicatorResponse>> GetRolIndicator(RolIndicatorRequest request)
        {
            var result = await _rolService.GetRolIndicator();
            return result.Select(r => new RolIndicatorResponse(r.RoleId, r.RolName,r.Indicator));
        }
        public async Task<SpInsUpdtResponse> EnableRolIndicator(EnableRolIndicatorRequest request)
        {
            var result = await _rolService.EnableRolIndicator(request.RolId,request.EnableIndicator,request.UserId);
            return new SpInsUpdtResponse { Succeded = result.Succeeded, Errors = result.Errors };
        }
        }
}
