using System.ComponentModel.DataAnnotations;

namespace FitnessPortal.Data.Entities
{
    public class FoodNutrition
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
		public string Name { get; set; }
        [Required]
        public int Category { get; set; }
        [Required]
        public float Kcal { get; set; }
        public List<FoodJournal> FoodJournals { get; set; } = [];
    }
}
