using FitnessPortal.Data;
using FitnessPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessPortal.Services
{
	public class FoodService : IFoodService
	{
		private readonly ApplicationDbContext _context;

		public FoodService(ApplicationDbContext context)
		{
			_context = context;
			_context.Database.EnsureCreated();
		}

		public async Task<IEnumerable<FoodNutrition>> GetFoodNutrition(string name)
		{
			var foodList = await _context.FoodsNutrition.ToListAsync();
			if (string.IsNullOrEmpty(name))
				return foodList.ToList();
			return foodList.Where(x => x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
		}
	}
}
