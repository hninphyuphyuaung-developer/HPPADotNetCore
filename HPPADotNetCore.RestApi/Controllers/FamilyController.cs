using HPPADotNetCore.RestApi.EFDbContext;
using HPPADotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace HPPADotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public FamilyController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult GetFamily()
        {
            var lst = _appDbContext.Families.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetFamily(int id)
        {
            FamilyResponseModel model = new FamilyResponseModel();
            var item = _appDbContext.Families.FirstOrDefault(x => x.FamilyId == id);
            if (item == null)
            {
                model.IsSuccess = false;
                model.Message = "No data found";
                return NotFound(model);
            }
            model.IsSuccess = true;
            model.Message = "Success.";
            model.Data = item;
            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateFamily([FromBody] FamilyDataModel family)
        {
            FamilyResponseModel model = new FamilyResponseModel();
            _appDbContext.Families.Add(family); 
            var result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Saving successful." : "Saving failed.";

            model.IsSuccess = result> 0;
            model.Message = message;
            model.Data = family;
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFamily(int id , [FromBody] FamilyDataModel family)
        {
            FamilyResponseModel model = new FamilyResponseModel();
            var item = _appDbContext.Families.FirstOrDefault(x => x.FamilyId == id);
            if (item == null)
            {
                return NotFound("No data found");
            }
            item.ParentName = family.ParentName;
            item.SonName = family.SonName;
            item.DaughterName = family.DaughterName;

            var result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Updating successful" : "Updating failed";

            model.IsSuccess = result > 0;
            model.Message = message;
            return Ok(model);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchFamily(int id, [FromBody] FamilyDataModel family)
        {
            FamilyResponseModel model = new FamilyResponseModel();
            var item = _appDbContext.Families.FirstOrDefault(x => x.FamilyId == id);
            if (item == null)
            {
                return NotFound("No data found");
            }

            if (!string.IsNullOrWhiteSpace(family.ParentName))
            {
                item.ParentName = family.ParentName;
            }
            if (!string.IsNullOrWhiteSpace(family.SonName))
            {
                item.SonName = family.SonName;
            }
            if (!string.IsNullOrWhiteSpace(family.DaughterName))
            {
                item.DaughterName = family.DaughterName;
            }

            var result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Updating successful" : "Updating failed";

            model.IsSuccess = result > 0;
            model.Message = message;
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFamily(int id)
        {
            FamilyResponseModel model = new FamilyResponseModel();
            var item = _appDbContext.Families.FirstOrDefault(x => x.FamilyId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            _appDbContext.Families.Remove(item);
            var result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

            model.IsSuccess = result > 0;
            model.Message = message;

            return Ok(model);
        }
    }
}
