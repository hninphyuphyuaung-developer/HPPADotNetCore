using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.MvcApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult PieChart()
        {
            return View();

        }

        public IActionResult HorizontalBarChart()
        {
            return View();
        }
    }
}
