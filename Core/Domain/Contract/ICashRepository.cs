using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public  interface ICashRepository
    {
        // Has Two methods, one for adding cash and another for getting the current cash balance.
        Task<string?> GetCashAsync(string Key);
        //                            make Value Object to allow any type of value to be stored
        Task SetCashAsync(string Key, object value, TimeSpan? Duration = null);

    }
}
