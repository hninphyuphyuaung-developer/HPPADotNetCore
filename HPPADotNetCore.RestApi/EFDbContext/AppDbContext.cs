using HPPADotNetCore.RestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HPPADotNetCore.RestApi.EFDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<FamilyDataModel> Families { get; set; }    
    }
}
