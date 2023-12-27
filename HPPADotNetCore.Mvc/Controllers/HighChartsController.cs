using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.MvcApp.Controllers
{
    public class HighChartsController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }
    }
}
