using Microsoft.AspNetCore.Mvc;

namespace GamersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly DataContext context;

        public UserController(DataContext context)
        {
            this.context = context;
        }
    }
}
