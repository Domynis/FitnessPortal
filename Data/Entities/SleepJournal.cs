using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPortal.Data.Entities
{
    public class SleepJournal
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        [ForeignKey("UserID")]
        public Guid UserID { get; set; }
        public User User { get; set; } = null!;
    }
}
