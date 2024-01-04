using HPPADotNetCore.AtmMvcApp.EFDbContext;
using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.AtmMvcApp.Controllers
{
    public class AtmController : Controller
    {
        private readonly AtmDbContext _db;

        public AtmController(AtmDbContext db)
        {
            _db = db;
        }

        public IActionResult CheckBalance()
        {
            return View();
        }

        public IActionResult Withdraw()
        {
            return View();
        }

        public IActionResult Deposit()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
