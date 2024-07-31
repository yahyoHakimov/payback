using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using payback.Server.DB;
using payback.Server.Models;

namespace payback.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly PaybackContext _context;

        public UserController(PaybackContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] User login)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
    }

}
