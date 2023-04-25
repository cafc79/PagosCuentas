namespace PAT.Models.Configuration;

public class AuthSettings
{
    public string SymetricKey { get; set; } = "";
    /// <summary>
    /// In hours
    /// </summary>
    public double JwtTokenExpiration { get; set; }
}