using FitnessPortal.Data;
using FitnessPortal.Data.DTOs;
using FitnessPortal.Data.Entities;
using FitnessPortal.Utils;
using Microsoft.EntityFrameworkCore;

namespace FitnessPortal.Services
{
	public class FoodJournalService : IFoodJournalService
	{
		private readonly ApplicationDbContext _context;
		public FoodJournalService(ApplicationDbContext context)
		{
			_context = context;
			_context.Database.EnsureCreated();
		}
		public void AddFoodJournalEntry(FoodDTO foodDTO)
		{
			FoodNutrition foodNutrition = _context.FoodsNutrition.FirstOrDefault(x => x.ID == foodDTO.Food.ID);

			if (foodNutrition == null)
			{
				throw new Exception("Food with ID " + foodDTO.Food.ID + " does not exist.");
			}

			FoodJournal model = new()
			{
				ID = Guid.Empty,
				UserID = foodDTO.UserID,
				Quantity = foodDTO.Quantity,
				Date = foodDTO.Date ?? DateTime.Today,
				FoodNutritionID = foodNutrition.ID,
				KcalTotal = KcalCalculator.Calc(foodDTO.Food.Kcal, foodDTO.Quantity),
			};

			_context.FoodsJournal.Add(model);

			_context.SaveChanges();
		}

		public List<FoodJournal> GetFoodJournals(DateTime startDate, DateTime endDate)
		{
			var result = _context.FoodsJournal.Include(x => x.FoodNutrition).Where(x => x.Date.Date >= startDate.Date && x.Date.Date <= endDate.Date).OrderBy(x => x.Date).ToList();
			return result;
		}

		public List<Tuple<int, float>> GetTodayFoodJournalByCategoriesAndKcal()
		{
			var result = from fj in _context.FoodsJournal
						 join fn in _context.FoodsNutrition on fj.FoodNutritionID equals fn.ID
						 where fj.Date == DateTime.Today
						 group fj by fn.Category
						 into g
						 select new Tuple<int, float>( g.Key, g.Sum(x => x.KcalTotal) )
						 ;

			var listResult = result.ToList();

			return listResult;
		}
	}
}
