namespace PAT.Provider.Models;

public class EmailResponse
{
    public EmailResponse(bool sent, IEnumerable<string> errors)
    {
        Sent = sent;
        Errors = errors;
    }

    public bool Sent { get; set; }
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}
