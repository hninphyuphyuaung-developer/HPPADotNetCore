using HPPADotNetCore.MvcApp.EFDbContext;
using HPPADotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.MvcApp.Controllers
{
    public class FamilyController : Controller
    {
        private readonly AppDbContext _context;

        public FamilyController(AppDbContext context)
        {
            _context = context;
        }

        //Get / List
        [ActionName("Index")]
        public IActionResult FamilyIndex()
        {
            List<FamilyDataModel> lst = _context.families.ToList();
            return View("FamilyIndex",lst);
        }

        [ActionName("Create")]
        public IActionResult FamilyCreate() 
        {
            return View("FamilyCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> FamilySave(FamilyDataModel reqModel) 
        {
            await _context.families.AddAsync(reqModel);
            var result = await _context.SaveChangesAsync();
            string message = result > 0 ? "Saving successsful" : "Saving failed";
            TempData["Message"] = message;
            TempData["isSuccess"] = result > 0;

            return Redirect("/Family");
        }
    }
}
