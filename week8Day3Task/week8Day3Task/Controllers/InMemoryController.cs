using Microsoft.AspNetCore.Mvc;
using week8Day3Task.Services;

namespace week8Day3Task.Controllers
{
    public class InMemoryController : Controller
    {
        private readonly InMemoryService _inMemoryService;

        public InMemoryController(InMemoryService inMemoryService)
        {
            _inMemoryService = inMemoryService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _inMemoryService.GetUsersAsync();
            return View(users);
        }
    }
}
