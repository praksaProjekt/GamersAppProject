using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamersApp.Controllers
{
    public class BaseController : ControllerBase
    {
        protected int GetCurrentUserID()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userID = claims.Where(p => p.Type == "ID").FirstOrDefault()?.Value;
            return Int32.Parse(userID);
        }
    }
}