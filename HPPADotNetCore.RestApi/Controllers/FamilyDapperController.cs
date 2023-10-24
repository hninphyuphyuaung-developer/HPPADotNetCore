using Dapper;
using HPPADotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;

namespace HPPADotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyDapperController : ControllerBase
    {
        private readonly SqlConnectionStringBuilder _connectionStringBuilder;
        public FamilyDapperController(IConfiguration configuration)
        {
            _connectionStringBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DbConnection"));
        }

        [HttpGet]
        public IActionResult GetFamily()
        {
            string query = "select * from Tbl_Family";
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            List<FamilyDataModel> lst = db.Query<FamilyDataModel>(query).ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetFamily(int id)
        {
            FamilyResponseModel model = new FamilyResponseModel();

            string query = "select * from Tbl_Family where familyId = @familyId";
            FamilyDataModel family = new FamilyDataModel 
            {
                FamilyId = id
            };
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            var item = db.Query<FamilyDataModel>(query, family).FirstOrDefault();
            if (item == null)
            {
                model.IsSuccess = false;
                model.Message = "No data found!";
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

            string query = @"INSERT INTO [dbo].[Tbl_Family]
           ([ParentName]
           ,[SonName]
           ,[DaughterName])
     VALUES
           (@ParentName
           ,@SonName
           ,@DaughterName)";
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            var result = db.Execute(query, family);
            string message = result > 0 ? "Updating successful." : "Updating failed.";

            model.IsSuccess = result > 0;
            model.Message = message;
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFamily(int id, [FromBody] FamilyDataModel family)
        {
            FamilyResponseModel model = new FamilyResponseModel();

            string query = "select * from Tbl_Family where familyId = @familyId";
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            var item = db.Query<FamilyDataModel>(query, new { familyId = id }).FirstOrDefault();
            if (item is null)
            {
                model.IsSuccess = false;
                model.Message = "No data found!";
                return NotFound(model);
            }

            query = @"UPDATE [dbo].[Tbl_Family]
   SET [ParentName] = @ParentName
      ,[SonName] = @SonName
      ,[DaughterName] = @DaughterName
 WHERE FamilyId =  @FamilyId";
            using IDbConnection db2 = new SqlConnection(_connectionStringBuilder.ConnectionString);
            family.FamilyId = id;
            int result = db2.Execute(query, family);
            var message = result > 0 ? "Updating successful" : "Updating failed";

            model.IsSuccess = result > 0;
            model.Message = message;
            return Ok(model);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchFamily(int id, [FromBody] FamilyDataModel family)
        {
            FamilyResponseModel model = new FamilyResponseModel();

            string query = "select * from Tbl_Family where familyId = @familyId";
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            var item = db.Query<FamilyDataModel>(query, new { familyId = id }).FirstOrDefault();
            if (item is null)
            {
                model.IsSuccess = false;
                model.Message = "No data found!";
                return NotFound(model);
            }

            query = @"UPDATE [dbo].[Tbl_Family]
   SET [ParentName] = @ParentName
      ,[SonName] = @SonName
      ,[DaughterName] = @DaughterName
 WHERE FamilyId =  @FamilyId";

            if(!string.IsNullOrWhiteSpace(family.ParentName))
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
            
            using IDbConnection db2 = new SqlConnection(_connectionStringBuilder.ConnectionString);
            int result = db2.Execute(query, item);
            var message = result > 0 ? "Updating successful" : "Updating failed";

            model.IsSuccess = result > 0;
            model.Message = message;
            return Ok(model); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFamily(int id)
        {
            FamilyResponseModel model = new FamilyResponseModel();

            string query = "select * from Tbl_Family where familyId = @familyId";
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            var item = db.Query<FamilyDataModel>(query, new { familyId = id }).FirstOrDefault();
            if (item is null)
            {
                model.IsSuccess = false;
                model.Message = "No data found!";
                return NotFound(model);
            }

            query = @"DELETE FROM [dbo].[Tbl_Family]
      WHERE FamilyId = @FamilyId";
            FamilyDataModel family = new FamilyDataModel
            {
                FamilyId = id
            };
            using IDbConnection db2 = new SqlConnection(_connectionStringBuilder.ConnectionString);
            int result = db2.Execute(query, family);
            var message = result > 0 ? "Deleting successful" : "Deleting failed";

            model.IsSuccess = result > 0;
            model.Message = message;
            return Ok(model);
        }
    }
}
