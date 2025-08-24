using Villa_Project.Models.BaseModels;

namespace Villa_Project.Models
{
    public class Category : BaseModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<Villa> Villas { get; set; } = new List<Villa>();

    }
}
