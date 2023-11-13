using HPPADotNetCore.MvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HPPADotNetCore.MvcApp.EFDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<FamilyDataModel> families { get; set; }

    }
}
