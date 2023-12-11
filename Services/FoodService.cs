// Importing necessary namespaces for the class
using FitnessPortal.Data;
using FitnessPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Defining a service class for managing food-related operations
namespace FitnessPortal.Services
{
    /// <summary>
    /// Service class for handling operations related to food and nutrition within the Fitness Portal application.
    /// </summary>
    public class FoodService : IFoodService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor for the FoodService class.
        /// </summary>
        /// <param name="context">The DbContext representing the application's database context.</param>
        public FoodService(ApplicationDbContext context)
        {
            // Initializing the DbContext for the service and ensuring that the database is created.
            _context = context;
            _context.Database.EnsureCreated();
        }

        /// <summary>
        /// Asynchronously retrieves a collection of food nutrition information based on the provided food name.
        /// </summary>
        /// <param name="name">The name of the food for which to retrieve nutrition information.</param>
        /// <returns>
        /// A task representing the asynchronous operation that, when completed,
        /// contains an enumerable collection of FoodNutrition objects.
        /// </returns>
        public async Task<IEnumerable<FoodNutrition>> GetFoodNutrition(string name)
        {
            // Retrieve the list of all foods from the database.
            var foodList = await _context.FoodsNutrition.ToListAsync();

            // If the provided name is null or empty, return the entire list of foods.
            if (string.IsNullOrEmpty(name))
                return foodList.ToList();

            // If a name is provided, filter the list based on a case-insensitive partial match.
            return foodList.Where(x => x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
    }
}
