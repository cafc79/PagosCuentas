
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Domain.Models.UserManagement;

    public readonly record struct EditUserResult
    (
        bool Success,
        IEnumerable<string> Errors
    );