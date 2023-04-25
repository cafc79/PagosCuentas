namespace PAT.Application.Models.UserManagement;


public readonly record struct EditUserResponse
 (bool Success, IEnumerable<string> Errors);
