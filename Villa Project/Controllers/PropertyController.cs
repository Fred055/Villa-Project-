using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villa_Project.Context;

namespace Villa_Project.Controllers
{
    public class PropertyController : Controller
    {
        private readonly VillaDbContext _context;


        public PropertyController(VillaDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            return View(categories);
        }
    }
}
