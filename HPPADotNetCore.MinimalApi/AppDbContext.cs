using HPPADotNetCore.MinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HPPADotNetCore.MinimalApi.EFDbContext
{
	public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<FamilyDataModel> Families { get; set; }    
    }
}
