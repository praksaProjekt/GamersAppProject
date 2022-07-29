using GamersApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GamersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : BaseController
    {
        private readonly DataContext context;

        public ProfileController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var userProfile = await context.Profiles.FindAsync(id);

            if (userProfile == null)
            {
                return BadRequest();
            }

            return Ok(userProfile);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Profile profile)
        {
            context.Profiles.Update(profile);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
