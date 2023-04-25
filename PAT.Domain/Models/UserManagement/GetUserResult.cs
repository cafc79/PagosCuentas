namespace PAT.Domain.Models.UserManagement;

public readonly record struct GetUserResult(
    string UsuarioId,
    string Email,
    string NombrePila,
    bool EmailConfirmado,
    bool Bloqueado,
    bool Activo,
    IEnumerable<string> Roles,
    IEnumerable<string> Errors);