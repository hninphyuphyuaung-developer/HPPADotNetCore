using HPPADotNetCore.AtmWebApp.EFDbContext;
using HPPADotNetCore.AtmWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HPPADotNetCore.AtmWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var str = HttpContext.Session.GetString("LoginData");
            if (str == null) return Redirect("/login");

            LoginViewModel model = JsonConvert.DeserializeObject<LoginViewModel>(str);
            var email = model.Email;
            var password = model.Password;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            await _dbContext.registerModels.AddAsync(registerModel);
            var result = await _dbContext.SaveChangesAsync();
            string message = result > 0 ? "Successful" : "Please register again!";
            TempData["Message"] = message;
            return View("Register");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
