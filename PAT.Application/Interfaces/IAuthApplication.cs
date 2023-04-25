using PAT.Application.Models.Authentication;
using PAT.Application.Models.UserManagement;

namespace PAT.Application.Interfaces;

public interface IAuthApplication
{
    Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
    Task<ValidateTokenUserResponse> ValidateJwtTokenLogIn(ValidateTokenUserRequest validateTokenUserRequest);
    Task<RevokeTokenLogInResponse> RevokeJwtTokenLogIn(RevokeTokenLogInRequest request);
}

