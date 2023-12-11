// Importing necessary namespaces for the interface
using FitnessPortal.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

// Defining a service interface for managing food-related operations
namespace FitnessPortal.Services
{
    /// <summary>
    /// Interface for managing food-related operations within the Fitness Portal application.
    /// </summary>
    public interface IFoodService
    {
        /// <summary>
        /// Retrieves a collection of food nutrition information based on the provided food name.
        /// </summary>
        /// <param name="name">The name of the food for which to retrieve nutrition information.</param>
        /// <returns>
        /// A task representing the asynchronous operation that, when completed,
        /// contains an enumerable collection of FoodNutrition objects.
        /// </returns>
        Task<IEnumerable<FoodNutrition>> GetFoodNutrition(string name);
    }
}
