using PAT.Application.Models.UserManagement;

namespace PAT.Application.Interfaces;

public interface IUserApplication
{
    Task<ChangePasswordResponse> ChangeUserPassword(ChangePasswordRequest request);
    Task<ConfirmUserResponse> ConfirmUser(ConfirmUserRequest request);
    Task<CreateUserResponse> CreateUser(CreateUserRequest request);
    Task<DeleteUserResponse> DeleteUser(DeleteUserRequest request);
    Task<EditUserResponse> EditUser(EditUserRequest request);
    Task<EditUserRolResponse> EditUserRoles(EditUserRolRequest request);
    Task<IEnumerable<GetUserResponse>> GetAllUsers(GetUsersRequest request);
    Task<LockUnlockUserResponse> LockUser(EmailDataRequest request);
    Task<ResetPasswordResponse> ResetPassword(ResetPasswordRequest request);
    Task<RevokeTokenResponse> RevokeTokenConfirmation(RevokeTokenRequest request);
    Task<RevokeTokenLogInResponse> RevokeTokenLogIn(RevokeTokenLogInRequest request);

    Task<ResetPasswordResponse> SendPasswordResetLink(EmailDataRequest request);
    Task<LockUnlockUserResponse> UnlockUser(EmailDataRequest request);
  
}
