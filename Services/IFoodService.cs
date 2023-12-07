using FitnessPortal.Data.Entities;

namespace FitnessPortal.Services
{
	public interface IFoodService
	{
		public Task<IEnumerable<FoodNutrition>> GetFoodNutrition(string name);
	}
}
