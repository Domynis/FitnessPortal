using FitnessPortal.Data.Entities;

namespace FitnessPortal.Data.DTOs
{
	public class FoodDTO
	{
		public FoodNutrition Food = new FoodNutrition();
		public DateTime? Date = DateTime.Today;
		public float Quantity = 1;
		public Guid UserID = Guid.Empty;
	}
}
