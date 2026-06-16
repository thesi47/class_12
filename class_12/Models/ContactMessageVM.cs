using System.ComponentModel.DataAnnotations;

namespace class_12.Models
{
    public class ContactMessageVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage ="Name must be between 2 and 1000 characters")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage ="Following format is required: example@email.com")]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required(ErrorMessage ="Enter the Message....")]
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}
