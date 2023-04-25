namespace PAT.Application.Models.UserManagement
{
    public  readonly record struct  EditUserRolResponse
    (bool Success, IEnumerable<string> Errors);
}
