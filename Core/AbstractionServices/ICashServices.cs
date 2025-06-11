using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionServices
{
    public interface ICashServices
    {
        Task<string?> GetCashAsync(string key);
        Task SetCashAsync(string key, object value, TimeSpan? duration = null);
    }
}
