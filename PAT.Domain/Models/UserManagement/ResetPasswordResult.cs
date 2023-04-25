using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Domain.Models.UserManagement;

    public readonly record struct ResetPasswordResult
     (
        bool Success,
        string UserId, 
        string Token, 
        IEnumerable<string> Errors
     );

