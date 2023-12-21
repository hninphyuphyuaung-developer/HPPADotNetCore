using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.MvcApp.Controllers
{
    public class FamilyAjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
