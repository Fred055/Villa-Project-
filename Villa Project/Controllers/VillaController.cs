using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villa_Project.Context;
using Villa_Project.Models;

namespace Villa_Project.Controllers
{
    public class VillaController : Controller
    {
        private readonly VillaDbContext _context;
        public VillaController(VillaDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var villas = await _context.Villas.Include(v => v.Category).Where(v => !v.IsDeleted).ToListAsync();
            return View(villas);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.Where(category => !category.IsDeleted).ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Villa villa)
        {

            ViewBag.Categories = await _context.Categories.Where(category => !category.IsDeleted).ToListAsync();
            villa.CreatedAt = DateTime.Now;
            await _context.Villas.AddAsync(villa);
            await _context.SaveChangesAsync();
            return RedirectToAction();

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var hemenvilla = await _context.Villas.FirstOrDefaultAsync(v => v.Id == id && !v.IsDeleted);
            if (hemenvilla == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _context.Categories.Where(category => !category.IsDeleted).ToListAsync();
            return View(hemenvilla);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Villa villa)
        {
            var updatedvilla = await _context.Villas.FirstOrDefaultAsync(v => v.Id == id && !v.IsDeleted);
            updatedvilla.UpdatedAt = DateTime.Now;
            if (updatedvilla == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _context.Categories.Where(category => !category.IsDeleted).ToListAsync();
            updatedvilla.Image = villa.Image;
            updatedvilla.Description = villa.Description;
            updatedvilla.Price = villa.Price;
            updatedvilla.Adress = villa.Adress;
            updatedvilla.BedroomCount = villa.BedroomCount;
            updatedvilla.Area = villa.Area;
            updatedvilla.ParkingCount = villa.ParkingCount;
            updatedvilla.BathroomCount = villa.BathroomCount;
            updatedvilla.FloorCount = villa.FloorCount;
            updatedvilla.IsParkingAvailable = villa.IsParkingAvailable;
            updatedvilla.CategoryId = villa.CategoryId;
            _context.Villas.Update(updatedvilla);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}
