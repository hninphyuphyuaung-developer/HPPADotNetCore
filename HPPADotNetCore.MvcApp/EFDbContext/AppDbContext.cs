using HPPADotNetCore2.MvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HPPADotNetCore2.MvcApp.EFDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<FamilyDataModel> Families { get; set; }    
    }
}
