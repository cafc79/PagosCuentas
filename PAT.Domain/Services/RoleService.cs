using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PAT.Common.Extensions;
using PAT.Common.Interfaces;
using PAT.Domain.Interfaces;
using PAT.Domain.Models;
using PAT.Domain.Models.RoleManagement;
using PAT.Models.Database.Tablas;

namespace PAT.Domain.Services;

public class RoleService : IRoleService
{

    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ISqlRepository<DbContext> _sqlRepository;
    public RoleService(RoleManager<IdentityRole> roleManager, ISqlRepository<DbContext> sqlRepository)
    {
        _roleManager = roleManager;
        _sqlRepository = sqlRepository;
    }

    public async Task<CreateRoleResult> CreateRole(string role)
    {
        if (!await _roleManager.RoleExistsAsync(role))
        {
            var r = await _roleManager.CreateAsync(new IdentityRole { Name = role });
            return new(r.Succeeded, r.Errors.GetErrors());
        }
        return new(false, new[] { "El rol ya existe" });
    }

    public async Task<IEnumerable<RoleResult>> GetRoles()
    {
        var result = _roleManager.Roles.Select(r => new RoleResult(r.Id, r.Name, r.NormalizedName));
        return await result.ToListAsync();
    }
    public async Task<IEnumerable<RolPermisoResult>> GetRolPermissions()
    {
        var data = await _sqlRepository.QueryViewAsync<VWABCRolPermiso>(d => !string.IsNullOrEmpty(d.RolId));
        return data.Select(f => new RolPermisoResult
        {
            PermissionId = f.PermisoId,
            PermissionName = f.NombrePermiso,
            RoleId = f.RolId,
            RolName = f.NombreRol,
            Status = f.Estatus
        });

    }
    public async Task<IEnumerable<RolIndicatorResult>> GetRolIndicator()
    {
        var data = await _sqlRepository.QueryViewAsync<VWABCRolSemaforo>(d => !string.IsNullOrEmpty(d.RolId));
        return data.Select(f => new RolIndicatorResult
        {
            Indicator = f.Semaforo,
            RoleId = f.RolId,
            RolName = f.NombreRol

        });

    }
    public async Task<SPInsUpdtResult> EnableRolIndicator(string RolId, bool Semaforo , string UsuarioId)
    {
        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@RolId",
                            Value = RolId
                        },
                        new SqlParameter() {
                            ParameterName = "@Semaforo",
                            Value = Semaforo
                        },
                           new SqlParameter() {
                            ParameterName = "@UsuarioId",
                            Value =UsuarioId
                        }
            };

        var data = await _sqlRepository.InsertUpdateByStore("stp_ABC_Rol_Semaforo",
          param);
        return new SPInsUpdtResult { Succeeded = data > 0 };
    }

}
