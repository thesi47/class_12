namespace class_12.Entities
{
    public class Education
    {
        public int Id { get; set; }
        public string Instituition { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
