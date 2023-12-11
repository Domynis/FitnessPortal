using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPortal.Data.Entities
{
    public class UserDetails
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public double? BMI { get; set; }
        public int? KCalGoal { get; set; }
        [ForeignKey("UserID")]
        public Guid UserID { get; set; }
        public User User { get; set; } = null!;
    }
}
