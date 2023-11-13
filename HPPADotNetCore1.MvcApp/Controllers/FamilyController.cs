using HPPADotNetCore.MvcApp.EFDbContext;
using HPPADotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.MvcApp.Controllers
{
    public class FamilyController : Controller
    {
        private readonly AppDbContext _dbContext;

        public FamilyController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [ActionName("Index")]
        public IActionResult FamilyIndex()
        {
            //string a = "Hello World";
            //ViewData["Title2"] = a;
            //ViewData["Number"] = 2;
            //ViewBag.Number2 = 3;

            //TempData["Title2"] = a; 
            //TempData["Number"] = 2;
            //TempData["Number2"] = 3;
            return View("FamilyIndex");
            //return Redirect("/Home");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> FamilySave(FamilyDataModel family)
        {
            await _dbContext.AddAsync(family);
            var result = _dbContext.SaveChanges();
            TempData["IsSuccess"] = result > 0;
            TempData["Message"] = result > 0 ? "Saving successful." : "Saving failed.";
            return Redirect("/family");
        }
    }
}
