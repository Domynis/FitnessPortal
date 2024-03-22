using FitnessPortal.Data.Entities;
using FitnessPortal.Utils;

namespace FitnessPortal.Data.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for representing food-related information.
    /// </summary>
    public class FoodDTO
    {
        /// <summary>
        /// Gets or sets the associated FoodNutrition object.
        /// </summary>
        public FoodNutrition Food { get; set; } = new FoodNutrition();

        /// <summary>
        /// Gets or sets the name of the food.
        /// </summary>
        public string FoodName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date associated with the food entry.
        /// </summary>
        public DateTime? Date { get; set; } = DateTime.Today;

        /// <summary>
        /// Gets or sets the formatted string representation of the date.
        /// </summary>
        public string DateString { get; set; } = DateTime.Today.ToString("dd.MM.yyyy");

        /// <summary>
        /// Gets or sets the quantity of the food consumed.
        /// </summary>
        public double Quantity { get; set; } = 1;

        /// <summary>
        /// Gets or sets the total kcal calculated for the food entry.
        /// </summary>
        public double KcalTotal { get; set; } = 0;

        /// <summary>
        /// Gets or sets the user ID associated with the food entry.
        /// </summary>
        public Guid UserID { get; set; } = Guid.Empty;

        /// <summary>
        /// Gets or sets the unique identifier for the food entry.
        /// </summary>
        public Guid ID { get; set; } = Guid.Empty;

        /// <summary>
        /// Creates a FoodDTO object from a FoodJournal object.
        /// </summary>
        /// <param name="journal">The FoodJournal object to create the FoodDTO from.</param>
        /// <returns>The created FoodDTO object.</returns>
        public static FoodDTO From(FoodJournal journal)
        {
            return new FoodDTO
            {
                ID = journal.ID,
                UserID = journal.UserID,
                Quantity = journal.Quantity,
                DateString = journal.Date.ToString("dd/MM/yyyy"),
                Date = journal.Date,
                Food = journal.FoodNutrition,
                FoodName = journal.FoodNutrition.Name,
                KcalTotal = journal.KcalTotal,
            };
        }

        /// <summary>
        /// Updates the properties of a FoodJournal object using the current FoodDTO.
        /// </summary>
        /// <param name="foodJournal">The FoodJournal object to update.</param>
        public void Update(FoodJournal foodJournal)
        {
            foodJournal.ID = ID;
            foodJournal.UserID = UserID;
            foodJournal.Quantity = Quantity;
            foodJournal.Date = Date ?? DateTime.Today;
            foodJournal.FoodNutritionID = Food.ID;
            foodJournal.KcalTotal = KcalCalculator.Calc(Food.Kcal, Quantity);
        }
    }
}
