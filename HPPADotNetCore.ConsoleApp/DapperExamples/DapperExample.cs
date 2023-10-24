using Dapper;
using HPPADotNetCore.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPADotNetCore.ConsoleApp.DapperExamples
{
    public class DapperExample
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
            //Read();
            //Create("Name", "Name", "Name");
            Edit(2);
            Edit(100);
            //Update(11, "Name", "Name", "Name");
            //Delete(20);
        }
        private void Read()
        {
            string query = "select * from Tbl_Family";
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            List<FamilyDataModel> lst=db.Query<FamilyDataModel>(query).ToList();

            foreach (FamilyDataModel item in lst)
            {
                Console.WriteLine(item.FamilyId);
                Console.WriteLine(item.ParentName);
                Console.WriteLine(item.SonName);
                Console.WriteLine(item.DaughterName);
                Console.WriteLine("___________________________");
            }
        }
        private void Create(string parent, string son, string daughter)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Family]
           ([ParentName]
           ,[SonName]
           ,[DaughterName])
     VALUES
           (@ParentName
           ,@SonName
           ,@DaughterName)";
            FamilyDataModel family = new FamilyDataModel
            {
                ParentName = parent,
                SonName = son,
                DaughterName = daughter
            };
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, family);
            string message = result > 0 ? "Saving successful." : "Saving failed.";
            Console.WriteLine(message);
        }

        private void Edit(int id)
        {
            string query = "select * from Tbl_Family where FamilyId = @FamilyId";
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            FamilyDataModel family = new FamilyDataModel
            {
                FamilyId = id,
            };
            FamilyDataModel? item = db.Query<FamilyDataModel>(query,family).FirstOrDefault();
            //FamilyDataModel? item = db.Query<FamilyDataModel>(query,new { FamilyId = id}).FirstOrDefault();
            if (item == null)
            {
                Console.WriteLine("No data found!");
                return;
            }

                Console.WriteLine(item.FamilyId);
                Console.WriteLine(item.ParentName);
                Console.WriteLine(item.SonName);
                Console.WriteLine(item.DaughterName);
                Console.WriteLine("___________________________");
        }

        private void Update(int id, string parent, string son, string daughter)
        {
            string query = @"UPDATE [dbo].[Tbl_Family]
   SET [ParentName] = @ParentName
      ,[SonName] = @SonName
      ,[DaughterName] = @DaughterName
 WHERE FamilyId =  @FamilyId";
            FamilyDataModel family = new FamilyDataModel
            {
                FamilyId = id,
                ParentName = parent,
                SonName = son,
                DaughterName = daughter
            };
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, family);
            string message = result > 0 ? "Updating successful." : "Updating failed.";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Family]
      WHERE @FamilyId = FamilyId";
            FamilyDataModel family = new FamilyDataModel
            {
                FamilyId = id,
            };
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, family);
            string message = result > 0 ? "Deleting successful." : "Deleting failed.";
            Console.WriteLine(message);
        }
    }
}
