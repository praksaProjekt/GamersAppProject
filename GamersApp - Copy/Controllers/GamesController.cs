using GamersApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GamersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : BaseController
    {
        private readonly DataContext context;

        public GamesController(DataContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Game>>> AddGame(Game game)
        {
            context.Games.Add(game);
            await context.SaveChangesAsync();

            return Ok(await context.Games.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Game>>> Delete(int id)
        {
            var dbGame = await context.Games.FindAsync(id);

            if (dbGame == null)
            {
                return BadRequest("Game not found.");
            }

            context.Games.Remove(dbGame);
            await context.SaveChangesAsync();

            return Ok(await context.Games.ToListAsync());
        }
    }
}
