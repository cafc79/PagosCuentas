using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Application.Models.EgressManagement
{
    public readonly record struct PaymentHistoryResponse
    (
    string Type,
    string Concept,
      string PaymentRequest,
    DateTime OriginalDate,
    DateTime PaymentDate,
    decimal PaymentMount,
    string WayToPay,
    string Provider,
    string Company,
    IEnumerable<string> Errors
   );
}
