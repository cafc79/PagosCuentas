using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Application.Models.Authentication
{
    public readonly record struct ValidateTokenUserRequest
   (
    string JwtToken,
    string Email,
    string Token
        );
}
