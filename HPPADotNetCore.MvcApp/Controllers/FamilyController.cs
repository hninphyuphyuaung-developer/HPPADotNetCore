using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.MvcApp.Controllers
{
    public class FamilyController : Controller
    {
        [ActionName("Index")]
        public IActionResult FamilyIndex()
        {
            string a = "Hello World";
            ViewData["Title2"] = a;
            ViewData["Number"] = 2;
            ViewBag.Number2 = 3;

            TempData["Title2"] = a; 
            TempData["Number"] = 2;
            TempData["Number2"] = 3;
            return View("FamilyIndex");
            //return Redirect("/Home");
        }
    }
}
