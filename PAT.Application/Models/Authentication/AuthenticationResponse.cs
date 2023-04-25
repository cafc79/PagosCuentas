namespace PAT.Application.Models.Authentication;

public readonly record struct AuthenticationResponse(
    string Email,
    string? Token,
    bool Authenticated,
    bool IsLockedOut,
    bool IsNotAllowed,
    bool DoesNotExist,
    string? UsuarioId,
    string? NombrePila,
    IEnumerable<string> Roles);
