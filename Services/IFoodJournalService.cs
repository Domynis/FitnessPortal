using FitnessPortal.Data.DTOs;
using FitnessPortal.Data.Entities;

namespace FitnessPortal.Services
{
	public interface IFoodJournalService
	{
		void AddOrUpdateFoodJournalEntry(FoodDTO foodDTO);
		List<FoodDTO> GetFoodJournals(DateTime startDate, DateTime endDate, Guid UserID);
		void RemoveFoodJournalEntry(FoodDTO foodDTO);
		public List<Tuple<int, float>> GetTodayFoodJournalByCategoriesAndKcal(Guid UserID);
	}
}
