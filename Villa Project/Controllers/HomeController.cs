using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villa_Project.Context;
using Villa_Project.Models;
using Villa_Project.ViewModels;

namespace Villa_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly VillaDbContext _context;

        public HomeController(VillaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.Where(s => !s.IsDeleted).ToListAsync();

            var villas = await _context.Villas.Include(v => v.Category).Where(v => !v.IsDeleted).ToListAsync();


            var villaVM = villas.Select(v => new VillaVM()
            {
                Id = v.Id,
                Image = v.Image,
                CategoryName = v.Category.CategoryName,
                Price = v.Price,
                Address = v.Adress,
                Area = v.Area,
                BedroomCount = v.BedroomCount,
                BathroomCount = v.BathroomCount,
                ParkingCount = v.ParkingCount,
                FloorCount = v.FloorCount,
            });

            var villaSingleVm = villas.Select(v => new VillaSingleVM()
            {
                Id = v.Id,
                Image = v.Image,
                CategoryName = v.Category.CategoryName,
                Description = v.Description,
                BedroomCount = v.BedroomCount,
                BathroomCount = v.BathroomCount,
                IsParkingAvailable = v.IsParkingAvailable,
                FloorCount = v.FloorCount,
                Area = v.Area
            });

            var homeVm = new HomeVM()
            {
                Sliders = sliders,
                Villas = villaVM,
                VillaSingle = villaSingleVm
            };


            return View(homeVm);
        }

        public async Task<IActionResult> Create()
        {
            var slider = new Slider()
            {
                CityCountry = "New York, USA",
                CreatedAt = DateTime.UtcNow,
                Image = "banner-02.jpg",
                Title = "Luxury Villa in New York",

            };
            var slider1 = new Slider()
            {
                CityCountry = "Moscow, Russia",
                CreatedAt = DateTime.UtcNow,
                Image = "banner-03.jpg",
                Title = "Luxury Villa in Moscow ",

            };
            var slider2 = new Slider()
            {
                CityCountry = "Yevlax, Azerbaijan",
                CreatedAt = DateTime.UtcNow,
                Image = "banner-01.jpg",
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



