using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villa_Project.Context;
using Villa_Project.Models;
using Villa_Project.Services.Abstractions;

namespace Villa_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly VillaDbContext _context;
        private readonly ICategoryService _categoryService;
        public CategoryController(VillaDbContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {

            var categories = await _categoryService.GetAllAsync(page, pageSize);

            var totalItems = await _context.Categories.Where(c => !c.IsDeleted).CountAsync();

            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
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

            await _categoryService.Create(category);
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

            var result = await _categoryService.EditAsync(id, category);


            if (result == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }

    }
}
