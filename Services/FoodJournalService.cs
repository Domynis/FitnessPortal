﻿using FitnessPortal.Data;
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
		public void AddOrUpdateFoodJournalEntry(FoodDTO foodDTO)
		{
			FoodNutrition foodNutrition = _context.FoodsNutrition.FirstOrDefault(x => x.ID == foodDTO.Food.ID);

			if (foodNutrition == null)
			{
				throw new Exception("Food with ID " + foodDTO.Food.ID + " does not exist.");
			}
			//foodDTO.Food = foodNutrition;

			var model = _context.FoodsJournal.FirstOrDefault(x => x.ID == foodDTO.ID) ?? new();
			foodDTO.Update(model);
			if (model.ID == Guid.Empty)
			{
				_context.FoodsJournal.Add(model);
			}
			_context.SaveChanges();
		}

		public List<FoodDTO> GetFoodJournals(DateTime startDate, DateTime endDate, Guid UserID)
		{
			var result = _context.FoodsJournal.Include(x => x.FoodNutrition)
				.Where(x => x.Date.Date >= startDate.Date && x.Date.Date <= endDate.Date 
				&& x.UserID.Equals(UserID))
				.OrderBy(x => x.Date).Select(x => FoodDTO.From(x)).ToList();
			return result;
		}

		public List<Tuple<int, float>> GetTodayFoodJournalByCategoriesAndKcal(Guid UserID)
		{
			var result = from fj in _context.FoodsJournal
						 join fn in _context.FoodsNutrition on fj.FoodNutritionID equals fn.ID
						 where fj.Date == DateTime.Today && fj.UserID == UserID
						 group fj by fn.Category
						 into g
						 select new Tuple<int, float>( g.Key, g.Sum(x => x.KcalTotal) )
						 ;

			var listResult = result.ToList();

			return listResult;
		}

		public void RemoveFoodJournalEntry(FoodDTO foodDTO)
		{
			var model = _context.FoodsJournal.FirstOrDefault(x => x.ID == foodDTO.ID);
			if (model != null)
			{
				_context.Remove(model);
				_context.SaveChanges();
			}
		}
	}
}
