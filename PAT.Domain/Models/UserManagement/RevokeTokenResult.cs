namespace PAT.Domain.Models.UserManagement
{
    public readonly record struct RevokeTokenResult
    (bool Success, 
     IEnumerable<string> Errors);
}
