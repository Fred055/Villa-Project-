namespace Villa_Project.Models
{
    public class VillaSingleVM
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public decimal Area { get; set; }
        public int BedroomCount { get; set; }
        public sbyte BathroomCount { get; set; }
        public bool IsParkingAvailable { get; set; }
        public sbyte FloorCount { get; set; }

    }
}
