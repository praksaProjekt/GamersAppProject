using GamersApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GamersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGameController : BaseController
    {
        private readonly DataContext context;

        public UserGameController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserGame>>> Get(int id)
        {
            var result = await context.UserGames.Where(x => x.UserId == id).ToListAsync();
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<User>> Post(int id)
        {
            var result = await context.UserGames.Where(x => x.UserId == id).ToListAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id)
        {
            var result = await context.UserGames.Where(x => x.UserId == id).ToListAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var result = await context.UserGames.Where(x => x.UserId == id).ToListAsync();

            if (result == null)
            {
                return BadRequest();
            }

            context.RemoveRange(result);

            return Ok();
        }
    }
}
