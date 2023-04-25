using PAT.Domain.Models.UserManagement;

namespace PAT.Domain.Interfaces;

public interface IUserService
{
    Task<ChangePasswordResult> ChangeUserPassword(string email, string currentPassword, string newPassword);
    Task<ConfirmUserResult> ConfirmUser(string email, string code);
    AccountConfirmationData CreateAccountConfirmationData(string email, string token, string resetPasswordToken, string accountConfirmationUrl);
    ResetPasswordData CreateResetPasswordData(string email, string token, string resetPasswordUrl);
    Task<CreateUserResult> CreateUser(string email, string name, IEnumerable<string> roles);
    Task<DeleteUserResult> DeleteUser(string email);
    Task<EditUserRolResult> EditUserRoles(string email, IEnumerable<string> roles);
    Task<IEnumerable<GetUserResult>> GetAllUsers();
    Task<LockUnlockUserResult> LockUser(string email);
    Task<ResetPasswordResult> ResetPassword(string email, string token, string password);
    Task<RevokeTokenResult> RevokeTokenConfirmation(string email);
    Task<RevokeTokenLogInResult> RevokeTokenLogIn(string email, string loginProvider, string providerKey);
    Task<ResetPasswordResult> SendPasswordResetLink(string email);
    Task<LockUnlockUserResult> UnlockUser(string email);
    Task<EditUserResult> EditUser(string email, string emailNuevo,
        string telefono, bool telefonoConfirmado,
        bool emailConfirmado, bool habilitarDosFactores, DateTime?
        fechaFinalizaBloqueo, bool bloqueado, 
        int intentosFallidos, string nombrePila);
   

}
