using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPortal.Data.Entities
{
    /// <summary>
    /// Represents a food journal entry in the database.
    /// </summary>
    public class FoodJournal
    {
        /// <summary>
        /// Gets or sets the unique identifier for the food journal entry.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the food consumed in the entry.
        /// </summary>
        [Required]
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the total calories (Kcal) of the food consumed in the entry.
        /// </summary>
        [Required]
        public double KcalTotal { get; set; }

        /// <summary>
        /// Gets or sets the date of the food journal entry.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user associated with the food journal entry.
        /// </summary>
        [ForeignKey("UserID")]
        public Guid UserID { get; set; }

        /// <summary>
        /// Gets or sets the User object associated with the food journal entry.
        /// </summary>
        public User User { get; set; } = null!;

        /// <summary>
        /// Gets or sets the unique identifier of the food nutrition associated with the food journal entry.
        /// </summary>
        [ForeignKey("FoodNutritionID")]
        public Guid FoodNutritionID { get; set; }

        /// <summary>
        /// Gets or sets the FoodNutrition object associated with the food journal entry.
        /// </summary>
        public FoodNutrition FoodNutrition { get; set; } = null!;
    }
}
