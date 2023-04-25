namespace PAT.Application.Models.UserManagement;

public readonly record struct EditUserRequest(
    string JwtToken,
    string Email,
    string emailNuevo,
    string telefono, 
    bool emailConfirmado, 
    bool habilitarDosFactores, 
    DateTime? fechaFinalizaBloqueo, 
    bool bloqueado,
    bool telefonoConfirmado,
    int intentosFallidos,
    string nombrePila);
