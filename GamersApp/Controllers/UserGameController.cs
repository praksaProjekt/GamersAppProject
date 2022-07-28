using GamersApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GamersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGameController : ControllerBase
    {
        private readonly DataContext _context;

        public UserGameController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserGame>>> Get(int id)
        {
            var result = await _context.UserGames.Where(x => x.UserId == id).ToListAsync();
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<User>> Post(int id)
        {
            var result = await _context.UserGames.Where(x => x.UserId == id).ToListAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id)
        {
            var result = await _context.UserGames.Where(x => x.UserId == id).ToListAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var result = await _context.UserGames.Where(x => x.UserId == id).ToListAsync();

            if (result == null)
            {
                return BadRequest();
            }

            _context.RemoveRange(result);

            return Ok();
        }
    }
}
