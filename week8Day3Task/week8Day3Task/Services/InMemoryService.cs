using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using week8Day3Task.Models;

namespace week8Day3Task.Services
{
    public class InMemoryService
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            string key = "users-memory";

            if (_memoryCache.TryGetValue(key, out List<User>? users))
            {
                Console.WriteLine("🟢 Data from memory cache: " + users.Count);
                return users!;
            }

            await Task.Delay(5000);

            using var http = new HttpClient();
            var response = await http.GetStringAsync("https://jsonplaceholder.typicode.com/users");
            users = JsonConvert.DeserializeObject<List<User>>(response)!;

            _memoryCache.Set(key, users, TimeSpan.FromMinutes(5));

            Console.WriteLine("🔵 Data from API: " + users.Count);
            return users;
        }
    }
}
