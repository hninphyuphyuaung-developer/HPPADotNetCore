using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.MvcApp.Controllers
{
    public class CanvasJsController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }
    }
}
