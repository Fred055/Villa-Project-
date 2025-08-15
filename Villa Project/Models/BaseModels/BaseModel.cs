namespace Villa_Project.Models.BaseModel
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string IsDeleted { get; set; }

    }
}
