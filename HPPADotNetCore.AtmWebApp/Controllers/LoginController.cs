using HPPADotNetCore.AtmWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HPPADotNetCore.AtmWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            var str = HttpContext.Session.GetString("LoginData");
            if (!(str == null)) return Redirect("/");

            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel reqModel)
        {
            //login

            HttpContext.Session.SetString("LoginData", JsonConvert.SerializeObject(reqModel));
            return Redirect("/");
        }
    }
}
