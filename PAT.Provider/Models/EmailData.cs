using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Provider.Models
{
    public readonly record struct EmailData
    (
        string EmailToId,
        string EmailToName,
        string EmailSubject,
        string EmailBody
    );
}
