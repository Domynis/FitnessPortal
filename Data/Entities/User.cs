using FitnessPortal.Utils;
using System.ComponentModel.DataAnnotations;

namespace FitnessPortal.Data.Entities
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Roles { get; set; }
        public UserDetails UserDetails { get; set; }
        public List<FoodJournal> FoodJournals { get; set; } = [];
        public List<SleepJournal> SleepJournals { get; set; } = [];
    }
}
