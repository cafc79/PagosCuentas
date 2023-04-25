using PAT.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Provider.Interafaces
{
    public interface ISyncFinerioService
    {
        Task<SyncFinerioResponse> GetToken();
    }
}
