namespace PAT.Common.Extensions;

public static class ExceptionsExtensions
{
    public static List<string> GetErrors(this Exception exception)
    {
        var errors = new List<string>
        {
            exception.Message
        };
        if (exception.InnerException is not null)
            errors.Add(exception.InnerException.Message);
        return errors;
    }
}
