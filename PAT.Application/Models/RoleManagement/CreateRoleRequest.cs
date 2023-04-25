namespace PAT.Application.Models.RoleManagement;

public readonly record struct CreateRoleRequest( 
    string JwtToken,
    string RoleName);

