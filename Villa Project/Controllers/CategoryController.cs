using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villa_Project.Context;
using Villa_Project.Models;

namespace Villa_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly VillaDbContext _context;
        public CategoryController(VillaDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            Category? existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == category.CategoryName);
            if (existingCategory != null)
            {

                return NotFound();
            }
            category.CreatedAt = DateTime.Now;
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(actionName: "Index", controllerName: "Category");


        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            var updatedcategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
            if (updatedcategory == null)
            {
                return NotFound();
            }
            updatedcategory.CategoryName = category.CategoryName;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var hemenCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (hemenCategory == null)
            {
                return NotFound();
            }

            hemenCategory.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

    }
}
