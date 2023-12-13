using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessPortal.Data.Entities
{
    /// <summary>
    /// Represents nutritional information for a food item in the database.
    /// </summary>
    public class FoodNutrition
    {
        /// <summary>
        /// Gets or sets the unique identifier for the food nutrition entry.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the food item.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category of the food item.
        /// </summary>
        [Required]
        public int Category { get; set; }

        /// <summary>
        /// Gets or sets the calorie content (Kcal) of the food item.
        /// </summary>
        [Required]
        public double Kcal { get; set; }

        /// <summary>
        /// Gets or sets the list of food journals associated with this food item.
        /// </summary>
        public List<FoodJournal> FoodJournals { get; set; } = [];
    }
}
