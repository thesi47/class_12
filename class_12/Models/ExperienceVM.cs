using System.ComponentModel.DataAnnotations;

namespace class_12.Models
{
    public class ExperienceVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Company Name is required....")]
        public string Company { get; set; }
        [Required(ErrorMessage = "What is your role in the company?")]
        public string Role { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage ="When did you start??")]
        public DateTime Startdate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
