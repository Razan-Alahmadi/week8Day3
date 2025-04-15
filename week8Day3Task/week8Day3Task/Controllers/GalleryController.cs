using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using week8Day3Task.Models;

namespace week8Day3Task.Controllers
{
    public class GalleryController : Controller
    {
        private readonly HttpClient _httpClient;

        public GalleryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/users");
            var users = JsonConvert.DeserializeObject<List<User>>(response);

            var images = users.Select((user, index) => new ImageItem
            {
                FileName = user.Name,
                Url = $"https://i.pravatar.cc/250?img={index + 1}"
            }).ToList();

            return View(images);
        }
    }
}
