using Microsoft.AspNetCore.Identity;

namespace class_12.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
