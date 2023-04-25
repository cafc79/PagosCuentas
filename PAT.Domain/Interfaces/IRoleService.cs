using PAT.Domain.Models;
using PAT.Domain.Models.RoleManagement;

namespace PAT.Domain.Interfaces;

public interface IRoleService
{
    Task<CreateRoleResult> CreateRole(string role);
    Task<IEnumerable<RoleResult>> GetRoles();
    Task<IEnumerable<RolPermisoResult>> GetRolPermissions();
    Task<IEnumerable<RolIndicatorResult>> GetRolIndicator();
    Task<SPInsUpdtResult> EnableRolIndicator(string RolId, bool Semaforo, string UsuarioId);
}

