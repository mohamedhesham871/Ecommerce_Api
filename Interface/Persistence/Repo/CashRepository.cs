using Domain.Contract;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence.Repo
{
    public class CashRepository(IConnectionMultiplexer connection) : ICashRepository
    {
        private readonly IDatabase _database =connection.GetDatabase();

        public async Task<string?> GetCashAsync(string Key)
        {
            var value = await _database.StringGetAsync(Key);

            if (value.IsNullOrEmpty)
            {
                return null;
            }
            return value;
        }

        public async Task SetCashAsync(string Key, object value, TimeSpan? Duration = null)
        {
            // Should make Value Json to Be Stored in Redis
            var valueJson = JsonSerializer.Serialize(value);

           await _database.StringSetAsync(Key, valueJson, Duration ?? TimeSpan.FromDays(30));
            // Store the Json in Redis with Key and Duration
            // If Duration is null, it will default to 30 days

            // if there Error Does not throw exception, just return nothing [it's not a critical error]

        }
    }
}
