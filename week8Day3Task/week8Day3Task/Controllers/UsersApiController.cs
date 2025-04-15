using Microsoft.AspNetCore.Mvc;
using week8Day3Task.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace week8Day3Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersApiController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public UsersApiController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var response = await _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/users");

            var users = JsonConvert.DeserializeObject<List<User>>(response);

            return Ok(users);
        }
    }
}
