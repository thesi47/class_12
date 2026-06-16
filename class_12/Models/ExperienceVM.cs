namespace class_12.Models
{
    public class ExperienceVM
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
