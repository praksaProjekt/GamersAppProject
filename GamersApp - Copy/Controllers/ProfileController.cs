using GamersApp.Entities;
using GamersApp.Services.ProfileServices;
using Microsoft.AspNetCore.Mvc;

namespace GamersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : BaseController
    {
        private readonly IProfileServices profileServices;

        public ProfileController(IProfileServices profileServices)
        {
            this.profileServices = profileServices ?? throw new ArgumentNullException(nameof(profileServices));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var userProfile = await profileServices.Get(id);

            if (userProfile == null)
            {
                return BadRequest();
            }

            return Ok(userProfile);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Profile profile)
        {
            await profileServices.Put(profile);
            return Ok();
        }
    }
}
