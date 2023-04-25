using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Application.Models.RoleManagement
{
    public readonly record struct EnableRolIndicatorRequest
  (
        string RolId, bool EnableIndicator, string UserId
        );
}
