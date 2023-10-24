using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPADotNetCore.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "HppaDotNetCore",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };

        public void Run()
        {
            //Create("U Aye", "Arkar", "Ingyin");
            //Read();
            //Edit(18);
            Update(17, "Alex", "Kelvin", "Rosa");
            Delete(16);
        }

        private void Read()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("connection opening");
            sqlConnection.Open();
            Console.WriteLine("connection opened");

            string query = "select * from Tbl_Family";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Console.WriteLine("connection closing");
            sqlConnection.Close();
            Console.WriteLine("connection closed");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["FamilyId"]);
                Console.WriteLine(dr["ParentName"]);
                Console.WriteLine(dr["SonName"]);
                Console.WriteLine(dr["DaughterName"]);
                Console.WriteLine("___________________________");
            }
        }
        private void Create(string parent , string son , string daughter)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
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
            cmd.Parameters.AddWithValue("@ParentName",parent);
            cmd.Parameters.AddWithValue("@SonName", son);
            cmd.Parameters.AddWithValue("@DaughterName", daughter);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Saving successful." : "Saving failed.";
            Console.WriteLine(message);

            sqlConnection.Close();
        }

        private void Edit(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
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
                Console.WriteLine("No data found!");
                return;
            }

            DataRow dr = dt.Rows[0];
                Console.WriteLine(dr["FamilyId"]);
                Console.WriteLine(dr["ParentName"]);
                Console.WriteLine(dr["SonName"]);
                Console.WriteLine(dr["DaughterName"]);
                Console.WriteLine("___________________________");
        }

        private void Update(int id , string parent, string son, string daughter)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = @"UPDATE [dbo].[Tbl_Family]
   SET [ParentName] = @ParentName
      ,[SonName] = @SonName
      ,[DaughterName] = @DaughterName
 WHERE FamilyId =  @FamilyId";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@FamilyId", id);
            cmd.Parameters.AddWithValue("@ParentName", parent);
            cmd.Parameters.AddWithValue("@SonName", son);
            cmd.Parameters.AddWithValue("@DaughterName", daughter);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Updating successful." : "Updating failed.";
            Console.WriteLine(message);

            sqlConnection.Close();
        }

        private void Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = @"DELETE FROM [dbo].[Tbl_Family]
      WHERE FamilyId = @FamilyId";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@FamilyId", id);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Deleting successful." : "Deleting failed.";
            Console.WriteLine(message);

            sqlConnection.Close();
        }

    }
}
