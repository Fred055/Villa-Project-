using Microsoft.AspNetCore.Mvc;

namespace Villa_Project.Models.BaseModels
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string IsDeleted { get; set; }


        public async Task<IActionResult> Index()
        {
            var? sliders = await _context.Sliders.Where(s => !s.IsDeleted).ToListAsync();

            return View(sliders);

        }
    }
}
