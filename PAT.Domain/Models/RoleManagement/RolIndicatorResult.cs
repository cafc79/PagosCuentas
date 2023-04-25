using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Domain.Models.RoleManagement
{
    public readonly record struct  RolIndicatorResult
    (
        string RoleId,
         string RolName,
         bool  Indicator
    );
}
