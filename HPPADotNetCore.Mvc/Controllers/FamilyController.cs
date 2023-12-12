using HPPADotNetCore.MvcApp.EFDbContext;
using HPPADotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            string message = result > 0 ? "Saving successful" : "Saving failed";
            TempData["Message"] = message;
            TempData["isSuccess"] = result > 0;

            return Redirect("/Family");
        }

        [ActionName("Edit")]
        public async Task<IActionResult> FamilyEdit(int id) 
        {
            if(!await _context.families.AsNoTracking().AnyAsync(x=> x.FamilyId == id))
            {
                TempData["Message"] = "No data found";
                TempData["isSuccess"] = false;
                return Redirect("/Family");
            }
            var family = await _context.families.AsNoTracking().FirstOrDefaultAsync(x => x.FamilyId == id);
            if (family == null)
            {
                TempData["Message"] = "No data found";
                TempData["isSuccess"] = false;
                return Redirect("/Family");
            }
            return View("FamilyEdit", family);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> FamilyUpdate(int id,FamilyDataModel reqModel)
        {
            if (!await _context.families.AnyAsync(x => x.FamilyId == id))
            {
                TempData["Message"] = "No data found";
                TempData["isSuccess"] = false;
                return Redirect("/Family");
            }
            var family = await _context.families.FirstOrDefaultAsync(x => x.FamilyId == id);
            if (family == null)
            {
                TempData["Message"] = "No data found";
                TempData["isSuccess"] = false;
                return Redirect("/Family");
            }

            family.ParentName = reqModel.ParentName;
            family.SonName = reqModel.SonName;
            family.DaughterName = reqModel.DaughterName;

            int result = _context.SaveChanges();
            string message = result > 0 ? "Updating successful." : "Updating failed.";

            TempData["Message"] = message;
            TempData["isSuccess"] = result > 0;
            //return View("FamilyEdit", family);
            return Redirect("/Family");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> FamilyDelete(int id)
        {
            if (!await _context.families.AsNoTracking().AnyAsync(x => x.FamilyId == id))
            {
                TempData["Message"] = "No data found";
                TempData["isSuccess"] = false;
                return Redirect("/Family");
            }
            var family = await _context.families.FirstOrDefaultAsync(x => x.FamilyId == id);
            if (family == null)
            {
                TempData["Message"] = "No data found";
                TempData["isSuccess"] = false;
                return Redirect("/Family");
            }

            _context.Remove(family);
            int result = _context.SaveChanges();
            string message = result > 0 ? "Deleting successful." : "Deleting failed.";

            TempData["Message"] = message;
            TempData["isSuccess"] = result > 0;
            //return View("FamilyEdit", family);
            return Redirect("/Family");

        }
    }
}
