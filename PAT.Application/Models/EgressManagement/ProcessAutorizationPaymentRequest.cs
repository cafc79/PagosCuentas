using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Application.Models.EgressManagement
{
    public readonly record struct ProcessAutorizationPaymentRequest
   (
    int IdPaymentRequest, 
    string UserId, 
     string JwtToken
     );
}
