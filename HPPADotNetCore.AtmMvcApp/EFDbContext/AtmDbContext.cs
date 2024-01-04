using Microsoft.EntityFrameworkCore;

namespace HPPADotNetCore.AtmMvcApp.EFDbContext
{
    public class AtmDbContext
    {
        public AtmDbContext(DbContextOptions<AtmDbContext> options) : base(options) 
        { 
        }
    }
}
