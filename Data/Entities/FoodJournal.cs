using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPortal.Data.Entities
{
    public class FoodJournal
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public float Quantity { get; set; }
        [Required]
        public float KcalTotal { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("UserID")]
        public Guid UserID { get; set; }
        public User User { get; set; } = null!;

        [ForeignKey("FoodID")]
        public Guid FoodID { get; set; }
        public FoodNutrition FoodNutrition { get; set; } = null!;
    }
}
