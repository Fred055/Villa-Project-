using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villa_Project.Context;
using Villa_Project.Models;
using Villa_Project.Services.Concretes;

namespace Villa_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly VillaDbContext _context;
        public CategoryController(VillaDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            CategoryService service = new CategoryService(_context);
            var categories = await service.GetAllAsync(page, pageSize);

            var totalItems = await _context.Categories.Where(c => c.IsDeleted).CountAsync();

            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
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
            CategoryService service = new CategoryService(_context);

            await service.Create(category);
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
