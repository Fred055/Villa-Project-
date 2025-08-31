using Microsoft.EntityFrameworkCore;
using Villa_Project.Context;
using Villa_Project.Models;
using Villa_Project.Services.Abstractions;

namespace Villa_Project.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly VillaDbContext _context;
        public CategoryService(VillaDbContext context)
        {
            _context = context;
        }

        public async Task<string> Create(Category category)
        {

            Category? existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == category.CategoryName);
            if (existingCategory != null)
            {

                return "Category not found";
            }
            category.CreatedAt = DateTime.Now;
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return "Category created successfully";
        }



        public Task<string> DeleteAsync(int Id)
        {
            var hemenCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
            if (hemenCategory == null)
            {
                return "NotFound";
            }

            hemenCategory.IsDeleted = true;

            await _context.SaveChangesAsync();
            return $"{ nameof(hemenCategory)} deleted"
        }

        public async Task<Category> EditAsync(int Id, Category category)
        {
            var updatedcategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == Id && !c.IsDeleted);

            if (string.IsNullOrWhiteSpace(updatedCategory.CategroyName))
            { 
                    updatedCategory.CategoryName = category.CategoryName;
            }

            await _context.SaveChangesAsync();
            return updatedCategory;
        }

        public async async Task<List<Category>> GetAllAsync(int page = 1, int pageSize = 5)
        {
            var query = _context.Categories.Where(c => !c.IsDeleted).AsQueryable();
            int totalItems = await query.CountAsync();

            var categories = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();



            return categories;

        }
    }
}
