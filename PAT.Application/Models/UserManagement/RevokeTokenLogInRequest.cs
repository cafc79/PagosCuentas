namespace PAT.Application.Models.UserManagement;

public readonly record struct RevokeTokenLogInRequest
  (
     string JwtToken,
     string Email,
     string loginProvider, 
     string providerKey,
     string TokenLogIn
    );

