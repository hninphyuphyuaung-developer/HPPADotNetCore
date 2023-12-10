using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.MvcApp.Controllers
{
    public class FamilyController : Controller
    {
        [ActionName("Index")]
        public IActionResult FamilyIndex()
        {
            return View("FamilyIndex");
        }
    }
}
