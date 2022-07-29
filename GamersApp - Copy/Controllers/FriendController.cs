using GamersApp.Services.FriendServices;
using Microsoft.AspNetCore.Mvc;

namespace GamersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : BaseController
    {
        private readonly IFriendServices friendServices;

        public FriendController(IFriendServices friendServices)
        {
            this.friendServices = friendServices ?? throw new ArgumentNullException(nameof(friendServices));
        }


        [HttpGet("friends/{id}")]
        public async Task<IActionResult> GetAllFriends(int id)
        {
            var friends = await friendServices.GetAllFriends(id);
            return Ok(friends);
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveFriend(int id)
        {
            await friendServices.RemoveFriend(GetCurrentUserID(), id);
            return Ok();
        }
    }
}
