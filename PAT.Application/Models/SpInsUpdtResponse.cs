using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Application.Models
{
    public readonly record struct SpInsUpdtResponse
    (
        bool Succeded,
        IEnumerable<string> Errors
        );
}
