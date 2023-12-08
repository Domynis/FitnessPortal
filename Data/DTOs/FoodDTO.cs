using FitnessPortal.Data.Entities;
using FitnessPortal.Services;

namespace FitnessPortal.Data.DTOs
{
	public class FoodDTO
	{
		public FoodNutrition Food = new FoodNutrition();
		public string FoodName { get; set; }
		public DateTime? Date = DateTime.Today;
		public string DateString { get; set; }
		public float Quantity = 1;
		public float KcalTotal = 0;
		public Guid UserID = Guid.Empty;
		public Guid ID = Guid.Empty;

		public static FoodDTO From(FoodJournal journal)
		{
			return new FoodDTO
			{
				ID = journal.ID,
				UserID = journal.UserID,
				Quantity = journal.Quantity,
				DateString = journal.Date.ToString("dd/MM/yyyy"),
				Food = journal.FoodNutrition,
				FoodName = journal.FoodNutrition.Name,
				KcalTotal = journal.KcalTotal,
			};
		}

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
