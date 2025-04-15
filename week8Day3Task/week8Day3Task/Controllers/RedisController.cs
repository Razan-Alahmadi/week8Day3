using Microsoft.AspNetCore.Mvc;
using week8Day3Task.Services;

namespace week8Day3Task.Controllers
{
    public class RedisController : Controller
    {
        private readonly RedisService _redisService;

        public RedisController(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _redisService.GetUsersAsync();
            return View(users);
        }
    }
}
