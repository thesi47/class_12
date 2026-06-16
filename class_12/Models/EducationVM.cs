using System.ComponentModel.DataAnnotations;

namespace class_12.Models
{
    public class EducationVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Instituition Cannot be empty.....")]
        public string Instituition { get; set; }
        [Required(ErrorMessage ="Please Enter a Degree.....")]
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        [Required(ErrorMessage = "Starting date is mandatory.....")]
        
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
