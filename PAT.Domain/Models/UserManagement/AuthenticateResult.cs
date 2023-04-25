using Microsoft.AspNetCore.Identity;
using PAT.Models.Identity;

namespace PAT.Domain.Models.UserManagement;

public readonly record struct AuthenticateResult(
    PATUser? User,
    SignInResult? Result);