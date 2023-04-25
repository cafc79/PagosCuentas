namespace PAT.Domain.Models.UserManagement
{
    public readonly record struct RevokeTokenLogInResult
    (bool Success, 
     IEnumerable<string> Errors);
}
