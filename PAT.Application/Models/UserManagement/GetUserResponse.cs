namespace PAT.Application.Models.UserManagement;

public readonly record struct GetUserResponse(
    string Email,
    string NombrePila,
    bool EmailConfirmado,
    bool Bloqueado,
    bool Activo,
    string UsuarioId,
    IEnumerable<string> Roles,
    IEnumerable<string> Errors);