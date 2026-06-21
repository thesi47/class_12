using class_12.Entities;
namespace class_12.Models
{
    public class PortfolioVM
    {
        public PersonalInfo PersonalInfo { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Education> Educations { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
