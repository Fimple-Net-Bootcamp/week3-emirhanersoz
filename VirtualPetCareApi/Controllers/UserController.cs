using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VirtualPetCareApi.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : ControllerBase
    {
        private readonly GameDbContext _gameDbContext;
        public UserController(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                _gameDbContext.Users.Add(user);
                await _gameDbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _gameDbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("GetByUsername/{username}")]
        public IActionResult GetUserByUsername(string username)
        {
            var user = _gameDbContext.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return NotFound($"User with username '{username}' not found.");
            }

            return Ok(user);
        }
    }
}
