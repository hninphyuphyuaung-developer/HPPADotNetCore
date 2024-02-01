using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.AtmWebApp.Controllers
{
    public class AtmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
