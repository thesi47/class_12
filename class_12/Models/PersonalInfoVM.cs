using System.ComponentModel.DataAnnotations;

namespace class_12.Models
{
    public class PersonalInfoVM
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        [Url]
        public string Website { get; set; }
        [Url]
        public string LinkedIn { get; set; }
        [Url]
        public string Github { get; set; }
        public string Bio { get; set; }
        public string ProfileImageUrl { get; set; }
        public IFormFile ProfileImage { get; set; }

    }
}
