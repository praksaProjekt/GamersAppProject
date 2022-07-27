using Microsoft.AspNetCore.Mvc;

namespace GamersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfileController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var userProfile = await _context.Profiles.FindAsync(id);

            if (userProfile == null)
            {
                return BadRequest();
            }

            return Ok(userProfile);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Profile profile)
        {
            _context.Profiles.Update(profile);
            _context.SaveChanges();
            return Ok();
        }
    }
}
