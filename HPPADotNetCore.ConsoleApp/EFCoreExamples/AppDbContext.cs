using HPPADotNetCore.ConsoleApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPADotNetCore.ConsoleApp.EFCoreExamples
{
    public class AppDbContext : DbContext
    {
        private readonly SqlConnectionStringBuilder connectionStringBuilder=new SqlConnectionStringBuilder()
        {
            DataSource = ".", // server name
            InitialCatalog = "HPPADotNetCore", // database name
            UserID = "sa", // user name
            Password = "sa@123", // password
            TrustServerCertificate = true
        };
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionStringBuilder.ConnectionString);
            }
        }

        public DbSet<FamilyDataModel> families { get; set; }
    }
}
