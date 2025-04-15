using Newtonsoft.Json;
using StackExchange.Redis;
using week8Day3Task.Models;

namespace week8Day3Task.Services
{
    public class RedisService
    {
        public async Task<List<User>> GetUsersAsync()
        {
            var db = RedisConnectorHelper.Connection.GetDatabase();
            string key = "users-redis";
            string? cachedData = await db.StringGetAsync(key);

            if (!string.IsNullOrEmpty(cachedData))
            {
                var usersFromCache = JsonConvert.DeserializeObject<List<User>>(cachedData)!;
                Console.WriteLine("🟢 Data from cache: " + usersFromCache.Count);
                return usersFromCache;
            }

            await Task.Delay(5000);

            using var http = new HttpClient();
            var response = await http.GetStringAsync("https://jsonplaceholder.typicode.com/users");

            await db.StringSetAsync(key, response, TimeSpan.FromMinutes(5));

            var usersFromApi = JsonConvert.DeserializeObject<List<User>>(response)!;
            Console.WriteLine("🔵 Data from API: " + usersFromApi.Count);
            return usersFromApi;
        }
    }
}
