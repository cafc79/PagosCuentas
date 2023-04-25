using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Domain.Models
{
    public readonly record struct SPInsUpdtResult
    (bool Succeeded,
    IEnumerable<string> Errors);
}
