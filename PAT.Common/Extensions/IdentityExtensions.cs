using Microsoft.AspNetCore.Identity;

namespace PAT.Common.Extensions;

public static class IdentityExtensions
{
    public static IEnumerable<string> GetErrors(this IEnumerable<IdentityError> errors)
        => errors.Select(e => e.Description);
}
