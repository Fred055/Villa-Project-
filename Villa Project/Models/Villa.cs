using Villa_Project.Models.BaseModels;

namespace Villa_Project.Models
{
    public class Villa : BaseModel
    {
        public string Image { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Adress { get; set; }
        public sbyte BedroomCount { get; set; }
        public decimal Area { get; set; } // in square meters
        public sbyte ParkingCount { get; set; }
        public sbyte BathroomCount { get; set; }
        public sbyte FloorCount { get; set; }
        public bool IsParkingAvailable { get; set; }

        //relations
        //[ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } // Navigation property to Category
    }
}
