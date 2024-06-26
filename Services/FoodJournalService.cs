﻿using FitnessPortal.Data.DTOs;
using FitnessPortal.Data.Entities;
using FitnessPortal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FitnessPortal.Services
{
    /// <summary>
    /// Service class for managing food journal entries.
    /// </summary>
    public class FoodJournalService : IFoodJournalService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodJournalService"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public FoodJournalService(ApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        /// <inheritdoc/>
        public void AddOrUpdateFoodJournalEntry(FoodDTO foodDTO)
        {
            FoodNutrition? foodNutrition = _context.FoodsNutrition.FirstOrDefault(x => x.ID == foodDTO.Food.ID);

            if (foodNutrition == null)
            {
                throw new Exception("Food with ID " + foodDTO.Food.ID + " does not exist.");
            }

            var model = _context.FoodsJournal.FirstOrDefault(x => x.ID == foodDTO.ID) ?? new();
            foodDTO.Update(model);
            if (model.ID == Guid.Empty)
            {
                _context.FoodsJournal.Add(model);
            }
            _context.SaveChanges();
        }

        /// <inheritdoc/>
        public List<FoodDTO> GetFoodJournals(DateTime startDate, DateTime endDate, Guid UserID)
        {
            var result = _context.FoodsJournal
                .Include(x => x.FoodNutrition)
                .Where(x => x.Date.Date >= startDate.Date && x.Date.Date <= endDate.Date
                    && x.UserID.Equals(UserID))
                .OrderBy(x => x.Date)
                .Select(x => FoodDTO.From(x))
                .ToList();

            return result;
        }

        /// <inheritdoc/>
        public List<Tuple<int, double>> GetTodayFoodJournalByCategoriesAndKcal(Guid UserID)
        {
            return
            [
                .. _context.FoodsJournal.Where(x => x.Date == DateTime.Today && x.UserID == UserID)
                                .GroupBy(x => x.FoodNutrition.Category).Select(x => new Tuple<int, double>(x.Key, x.Sum(y => y.KcalTotal))),
            ];
        }

        /// <inheritdoc/>
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
