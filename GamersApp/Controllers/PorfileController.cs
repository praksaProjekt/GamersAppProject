using Microsoft.AspNetCore.Mvc;

namespace GamersApp.Controllers
{
    public class PorfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
