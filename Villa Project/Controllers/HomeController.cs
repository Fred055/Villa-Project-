using Microsoft.AspNetCore.Mvc;
using Villa_Project.Models;

namespace Villa_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly VillaDbContext _context;

        public HomeController(VillaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.Where(s => !s.IsDeleted).ToListAsync();

            return View();
        }

        public async Task<IActionResult> Create()
        {
            var slider? slider = new Slider()
            {
                CityCountry = "New York, USA",
                CreatedAt = DateTime.UtcNow,
                Image = "banner-02.jpg",
                Title = "Luxury Villa in New York",

            };
            var slider? slider1 = new Slider()
            {
                CityCountry = "Moscow, Russia",
                CreatedAt = DateTime.UtcNow,
                Image = "banner-02.jpg",
                Title = "Luxury Villa in Moscow ",

            };
            var slider? slider2 = new Slider()
            {
                CityCountry = "Yevlax, Azerbaijan",
                CreatedAt = DateTime.UtcNow,
                Image = "banner-02.jpg",
                Title = "Luxury Villa in Yevlax",

            };

            await _context.AddAsync(slider);
            await _context.AddAsync(slider1);
            await _context.AddAsync(slider2);

            await _context.SaveChangesAsync();


            return Json(data: "ok");
        }


    }
}



