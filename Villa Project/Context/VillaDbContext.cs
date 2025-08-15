using Microsoft.EntityFrameworkCore;
using Villa_Project.Models;

namespace Villa_Project.Context
{
    public class VillaDbContext : DbContext
    {
        public DbSet<Slider> Sliders { get; set; }
        public VillaDbContext(DbContextOptions<VillaDbContext> opt) : base(opt)
        {

        }

    }


}
