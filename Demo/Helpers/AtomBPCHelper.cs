using Atom.BPC;
using Atom.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public static class AtomBPCHelper
    {
        private static AtomBPCManager _MANAGER;
        public static async Task<AtomBPCManager> GetManager(string secretKey)
        {
            if (_MANAGER == null)
            {
                _MANAGER = await AtomBPCManager.InitializeAsync(new AtomConfiguration(secretKey));
            }
            return _MANAGER;
        }
    }
}
