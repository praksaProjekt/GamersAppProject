using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly DataContext _context;

        public GamesController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<List<Game>>> AddGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return Ok(await _context.Games.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Game>>> Delete(int id)
        {
            var dbGame = await _context.Games.FindAsync(id);
            if (dbGame == null)
                return BadRequest("Game not found.");

            _context.Games.Remove(dbGame);
            await _context.SaveChangesAsync();

            return Ok(await _context.Games.ToListAsync());
        }
    }
}
