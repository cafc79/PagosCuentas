namespace PAT.Models.Configuration;

public class EmailSettings
{
    public string AccountConfirmationUrl { get; set; } = "";
    public string ResetPasswordUrl { get; set; } = "";
    public string SendGridApiKey { get; set; } = "";
    public string SendGridFrom { get; set; } = "";
}
