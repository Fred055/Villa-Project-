namespace Villa_Project.ViewModels
{
    public class VillaVM
    {
        public Guid Id { get; set; }
        public string? Image { get; set; }
        public string? CategoryName { get; set; }
        public decimal Price { get; set; }
        public string? Address { get; set; }
        public decimal Area { get; set; }
        public int BedroomCount { get; set; }
        public sbyte BathroomCount { get; set; }
        public sbyte ParkingCount { get; set; }
        public sbyte FloorCount { get; set; }


    }
}
