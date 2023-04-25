namespace PAT.Application.Models.Authentication
{
    public readonly record struct AuthenticationRequest(
        string Email,
        string Password);
}
