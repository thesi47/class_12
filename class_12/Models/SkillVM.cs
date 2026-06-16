using System.ComponentModel.DataAnnotations;

namespace class_12.Models
{
    public class SkillVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage =("Name of the skill cannot be empty..."))]
        public string Name { get; set; }
        public string Category { get; set; }
        [Range(1,10,ErrorMessage ="This value must be from 1 to 10")]
        public int ProficiencyLevel { get; set; }
    }
}
