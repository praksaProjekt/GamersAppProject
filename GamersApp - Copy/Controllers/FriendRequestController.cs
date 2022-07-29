using GamersApp.Services.FriendRequestServices;
using Microsoft.AspNetCore.Mvc;

namespace GamersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendRequestController : BaseController
    {
        private readonly IFriendRequestServices friendRequestServices;

        public FriendRequestController(IFriendRequestServices friendRequestServices)
        {
            this.friendRequestServices = friendRequestServices ?? throw new ArgumentNullException(nameof(friendRequestServices));
        }

        [HttpGet("requestspending")]
        public async Task<IActionResult> GetAllRequestsPending()
        {
            var result = await friendRequestServices.GetAllRequestsPending(GetCurrentUserID());
            return Ok(result);
        }

        [HttpGet("requestssent")]
        public async Task<IActionResult> GetAllRequestsSent()
        {
            var result = await friendRequestServices.GetAllRequestsSent(GetCurrentUserID());
            return Ok(result);
        }


        [HttpPost("send/{id}")]
        public IActionResult SendFriendRequest(int id)
        {
            friendRequestServices.SendFriendRequest(GetCurrentUserID(), id);
            return Ok();
        }

        [HttpPost("accept/{id}")]
        public async Task<IActionResult> AcceptFriendRequest(int id)
        {
            await friendRequestServices.AcceptFriendRequest(GetCurrentUserID(), id);
            return Ok();
        }

        [HttpDelete("decline/{id}")]
        public async Task<IActionResult> RemoveFriendRequest(int id)
        {
            await friendRequestServices.RemoveFriendRequest(GetCurrentUserID(), id);
            return Ok();
        }
    }
}
