namespace class_12.Models
{
    public class EducationVM
    {
        public int Id { get; set; }
        public string Instituition { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
