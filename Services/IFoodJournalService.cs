using FitnessPortal.Data.DTOs;
using FitnessPortal.Data.Entities;

namespace FitnessPortal.Services
{
	public interface IFoodJournalService
	{
		void AddFoodJournalEntry(FoodDTO foodDTO);
		List<FoodJournal> GetFoodJournals(DateTime startDate, DateTime endDate);
		public List<Tuple<int, float>> GetTodayFoodJournalByCategoriesAndKcal();
	}
}
