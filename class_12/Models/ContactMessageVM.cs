using System.ComponentModel.DataAnnotations;

namespace class_12.Models
{
    public class ContactMessageVM
    {
        public int Id { get; set; }
        [Required]
        [Range(2,1000, ErrorMessage ="Name must be between 2 and 1000 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage ="email is required")]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required(ErrorMessage ="Enter the Message....")]
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}
