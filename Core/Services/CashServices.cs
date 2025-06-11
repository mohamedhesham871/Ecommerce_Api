using AbstractionServices;
using Domain.Contract;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CashServices(ICashRepository _cashRepo) : ICashServices
    {
        public async Task<string?> GetCashAsync(string key)
        {
            var result=await _cashRepo.GetCashAsync(key);
            return result is null ? null : result;

        }

        public async Task SetCashAsync(string key, object value, TimeSpan? duration = null)
        {
            await  _cashRepo.SetCashAsync(key, value, duration);

        }
    }
}
