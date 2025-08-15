using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Villa_Project.Context
{
    public class VillaDbContext : DbContext
    {
        PublicKey Dbset<Slider> Sliders { get; set; }
        public VillaDbContext(DbContextOptions<VillaDbContext> opt) : base(opt)
        {

        }

    }


}
