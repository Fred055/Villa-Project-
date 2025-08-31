using Villa_Project.Models;

namespace Villa_Project.Services.Abstractions
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllAsync(int page = 1, int pageSize = 5);
        public Task<string> Create(Category category);
        public Task<Category> EditAsync(int Id);
        public Task<string> DeleteAsync(int Id);

    }
}
