// Importing necessary namespaces for the interface
using FitnessPortal.Data.DTOs;
using FitnessPortal.Data.Entities;

// Defining a service interface for managing food journal entries
namespace FitnessPortal.Services
{
    /// <summary>
    /// Interface for managing food journal entries within the Fitness Portal application.
    /// </summary>
    public interface IFoodJournalService
    {
        /// <summary>
        /// Adds or updates a food journal entry.
        /// </summary>
        /// <param name="foodDTO">The FoodDTO object representing the food journal entry.</param>
        void AddOrUpdateFoodJournalEntry(FoodDTO foodDTO);

        /// <summary>
        /// Retrieves a list of food journal entries within a specified date range for a user.
        /// </summary>
        /// <param name="startDate">The start date of the range.</param>
        /// <param name="endDate">The end date of the range.</param>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>A list of FoodDTO objects representing the retrieved food journal entries.</returns>
        List<FoodDTO> GetFoodJournals(DateTime startDate, DateTime endDate, Guid UserID);

        /// <summary>
        /// Removes a specific food journal entry.
        /// </summary>
        /// <param name="foodDTO">The FoodDTO object representing the food journal entry to be removed.</param>
        void RemoveFoodJournalEntry(FoodDTO foodDTO);

        /// <summary>
        /// Gets today's food journal entries grouped by categories and their total kcal consumption.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A list of tuples where each tuple contains a category (integer) and the corresponding total kcal (double).
        /// </returns>
        List<Tuple<int, double>> GetTodayFoodJournalByCategoriesAndKcal(Guid UserID);
    }
}
