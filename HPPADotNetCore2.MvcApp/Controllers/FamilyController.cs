using HPPADotNetCore2.MvcApp.EFDbContext;
using HPPADotNetCore2.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HPPADotNetCore2.MvcApp.Controllers
{
    public class FamilyController : Controller
    {
        private readonly AppDbContext _context;

        public FamilyController(AppDbContext context)
        {
            _context = context;
        }

        [ActionName("Index")]
        public async Task<IActionResult> FamilyIndex(int pageNo = 1 , int pageSize = 10)
        {
            List<FamilyDataModel> lst = await _context.Families
                .AsNoTracking()
                .OrderByDescending(x => x.FamilyId)
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            int pageRowCount = await _context.Families.CountAsync();
            int pageCount = pageRowCount / pageSize;
            if(pageRowCount % pageSize > 0)
            {
                pageCount++;
            }

            //string a = "Hello World";
            //ViewData["Title2"] = a;
            //ViewData["Number"] = 2;

            //ViewBag.Number = 3;

            //TempData["Number"] = 3; 

            FamilyListResponseModel model = new FamilyListResponseModel 
            { 
                FamilyList = lst,
                PageNo = pageNo,
                PageSize = pageSize,
                PageCount = pageCount,
                PageRowCount = pageRowCount
            };
            return View("FamilyIndex" ,model);
            //return Redirect("/Home");
        }

        [ActionName("Create")]
        public IActionResult FamilyCreate()
        {
            //string a = "Hello World";
            //ViewData["Title2"] = a;
            //ViewData["Number"] = 2;

            //ViewBag.Number = 3;

            //TempData["Number"] = 3; 
            //return View("FamilyIndex");
            return Redirect("/FamilyCreate");
        }
       
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> FamilySave(FamilyDataModel family) {
            await _context.AddAsync(family);
            var result = await _context.SaveChangesAsync();
            TempData["IsSuccess"] = result > 0;
            TempData["Message"] = result > 0 ? "Saving successful" : "Saving failed";
            return Redirect("/Family");
        }
        
        public async Task<IActionResult> Generate()
        {
            for (int i = 1; i <= 1000; i++)
            {
                await _context.AddAsync(new FamilyDataModel
                {
                    ParentName = i.ToString(),
                    SonName = i.ToString(),
                    DaughterName = i.ToString(),
                });
                var result = await _context.SaveChangesAsync();
            }
            return Redirect("/Family");
        }

        [ActionName("Edit")]
        public async Task<IActionResult> FamilyEdit(int id)
        {
            bool isExist = await _context.Families.AsNoTracking().AnyAsync(x => x.FamilyId == id);
            if (!isExist)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "No data found.";
                return Redirect("/Family");
            }
            var item = await _context.Families.AsNoTracking().FirstOrDefaultAsync(x => x.FamilyId == id);
            if ( item == null)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "No data found.";
                return Redirect("/Family");
            }
            return View("FamilyEdit", item);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> FamilyUpdate(int id ,FamilyDataModel family)
        {
            bool isExist = await _context.Families.AsNoTracking().AnyAsync(x => x.FamilyId == id);
            if (!isExist)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "No data found.";
                return Redirect("/Family");
            }
            var item = await _context.Families.FirstOrDefaultAsync(x => x.FamilyId == id);
            if (item == null)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "No data found.";
                return Redirect("/Family");
            }

            item.ParentName = family.ParentName;
            item.SonName = family.SonName;
            item.DaughterName = family.DaughterName;

            var result = await _context.SaveChangesAsync();
            TempData["IsSuccess"] = result > 0;
            TempData["Message"] = result > 0 ? "Updating successful" : "Updating failed";
            return Redirect("/Family");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> FamilyDelete(int id)
        {
            bool isExist = await _context.Families.AsNoTracking().AnyAsync(x => x.FamilyId == id);
            if (!isExist)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "No data found.";
                return Redirect("/Family");
            }
            var item = await _context.Families.FirstOrDefaultAsync(x => x.FamilyId == id);
            if (item == null)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "No data found.";
                return Redirect("/Family");
            }

            _context.Families.Remove(item);
            var result = await _context.SaveChangesAsync();
            TempData["IsSuccess"] = result > 0;
            TempData["Message"] = result > 0 ? "Deleting successful" : "Deleting failed";
            return Redirect("/Family");
        }

    }
}
