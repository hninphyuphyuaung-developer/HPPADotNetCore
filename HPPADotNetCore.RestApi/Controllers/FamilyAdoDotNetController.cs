using HPPADotNetCore.RestApi.EFDbContext;
using HPPADotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace HPPADotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyAdoDotNetController : ControllerBase
    {
        private readonly SqlConnectionStringBuilder _connectionStringBuilder;
        public FamilyAdoDotNetController(IConfiguration configuration)
        {
            _connectionStringBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DbConnection"));
        }

        [HttpGet]
        public IActionResult GetFamily()
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = "select * from Tbl_Family";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            sqlConnection.Close();

            List<FamilyDataModel> lst = new List<FamilyDataModel>();
            foreach (DataRow dr in dt.Rows)
            {
                FamilyDataModel item = new FamilyDataModel();
                item.FamilyId = Convert.ToInt32(dr["FamilyId"]);
                item.ParentName = Convert.ToString(dr["ParentName"]);
                item.SonName = Convert.ToString(dr["SonName"]);
                item.DaughterName = Convert.ToString(dr["DaughterName"]);
                lst.Add(item);
            }
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetFamily(int id)
        {
            FamilyResponseModel model = new FamilyResponseModel();

            SqlConnection sqlConnection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = @"select * from Tbl_Family where FamilyId = @FamilyId";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@FamilyId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            sqlConnection.Close();

            if (dt.Rows.Count == 0)
            {
                model.IsSuccess = false;
                model.Message = "No data found!";
                return NotFound(model);
            }

            DataRow dr = dt.Rows[0];
            FamilyDataModel item = new FamilyDataModel();
            item.FamilyId = Convert.ToInt32(dr["FamilyId"]);
            item.ParentName = Convert.ToString(dr["ParentName"]);
            item.SonName = Convert.ToString(dr["SonName"]);
            item.DaughterName = Convert.ToString(dr["DaughterName"]);

            model.IsSuccess = true;
            model.Message = "Success.";
            model.Data = item;
            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateFamily([FromBody] FamilyDataModel family)
        {
            FamilyResponseModel model = new FamilyResponseModel();

            SqlConnection sqlConnection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = @"INSERT INTO [dbo].[Tbl_Family]
           ([ParentName]
           ,[SonName]
           ,[DaughterName])
     VALUES
           (@ParentName
           ,@SonName
           ,@DaughterName)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@ParentName", family.ParentName);
            cmd.Parameters.AddWithValue("@SonName", family.SonName);
            cmd.Parameters.AddWithValue("@DaughterName", family.DaughterName);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Saving successful." : "Saving failed.";
            Console.WriteLine(message);

            sqlConnection.Close();

            model.IsSuccess = result > 0;
            model.Message = message;
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFamily(int id, [FromBody] FamilyDataModel family)
        {
            FamilyResponseModel model = new FamilyResponseModel();

            SqlConnection sqlConnection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = "select * from Tbl_Family where FamilyId = @FamilyId";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@FamilyId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            sqlConnection.Close();

            if (dt.Rows.Count == 0)
            {
                model.IsSuccess = false;
                model.Message = "No data found!";
                return NotFound(model);
            }
            
            sqlConnection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            query = @"UPDATE [dbo].[Tbl_Family]
   SET [ParentName] = @ParentName
      ,[SonName] = @SonName
      ,[DaughterName] = @DaughterName
 WHERE FamilyId =  @FamilyId";
            cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@FamilyId", id);
            cmd.Parameters.AddWithValue("@ParentName", family.ParentName);
            cmd.Parameters.AddWithValue("@SonName", family.SonName);
            cmd.Parameters.AddWithValue("@DaughterName", family.DaughterName);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Updating successful." : "Updating failed.";
            Console.WriteLine(message);

            sqlConnection.Close();

            model.IsSuccess = result > 0;
            model.Message = message;
            return Ok(model);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchFamily(int id, [FromBody] FamilyDataModel family)
        {
            FamilyResponseModel model = new FamilyResponseModel();

            SqlConnection sqlConnection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = "select * from Tbl_Family where FamilyId = @FamilyId";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@FamilyId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            sqlConnection.Close();

            if (dt.Rows.Count == 0)
            {
                model.IsSuccess = false;
                model.Message = "No data found!";
                return NotFound(model);
            }

            sqlConnection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string queryConditions = string.Empty;
            if (!string.IsNullOrWhiteSpace(family.ParentName))
            {
                queryConditions += " [ParentName] = @ParentName, ";
            }
            if (!string.IsNullOrWhiteSpace(family.SonName))
            {
                queryConditions += " [SonName] = @SonName, ";
            }
            if (!string.IsNullOrWhiteSpace(family.DaughterName))
            {
                queryConditions += " [DaughterName] = @DaughterName, ";
            }
            queryConditions = queryConditions.Substring(0,queryConditions.Length-2);

            query = $@"UPDATE [dbo].[Tbl_Family]
   SET  {queryConditions}
 WHERE FamilyId =  @FamilyId";
            cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@FamilyId", id);
            if (!string.IsNullOrWhiteSpace(family.ParentName))
            {
                cmd.Parameters.AddWithValue("@ParentName", family.ParentName);
            }
            if (!string.IsNullOrWhiteSpace(family.SonName))
            {
                cmd.Parameters.AddWithValue("@SonName", family.SonName);
            }
            if (!string.IsNullOrWhiteSpace(family.DaughterName))
            {
                cmd.Parameters.AddWithValue("@DaughterName", family.DaughterName);
            }
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Updating successful." : "Updating failed.";
            Console.WriteLine(message);

            sqlConnection.Close();

            model.IsSuccess = result > 0;
            model.Message = message;
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFamily(int id)
        {
            FamilyResponseModel model = new FamilyResponseModel();

            SqlConnection sqlConnection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = "select * from Tbl_Family where FamilyId = @FamilyId";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@FamilyId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            sqlConnection.Close();

            if (dt.Rows.Count == 0)
            {
                model.IsSuccess = false;
                model.Message = "No data found!";
                return NotFound(model);
            }

            sqlConnection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            query = @"DELETE FROM [dbo].[Tbl_Family]
      WHERE FamilyId = @FamilyId";
            cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@FamilyId", id);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Deleting successful." : "Updating failed.";
            Console.WriteLine(message);

            sqlConnection.Close();

            model.IsSuccess = result > 0;
            model.Message = message;
            return Ok(model);
        }
    }
}
