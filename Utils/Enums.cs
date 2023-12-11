namespace FitnessPortal.Utils
{
    /// <summary>
    /// Provides enumeration types and extension methods related to roles, food categories, and chart period options.
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// Enumeration of user roles.
        /// </summary>
        public enum Roles { User, Admin }

        /// <summary>
        /// Gets the string representation of the specified role index.
        /// </summary>
        /// <param name="index">The index representing a user role (User or Admin).</param>
        /// <returns>The string representation of the user role (User or Admin).</returns>
        public static string GetRoleString(this int index)
        {
            if (Enum.IsDefined(typeof(Roles), index))
            {
                return ((Roles)index).ToString();
            }
            else
            {
                return "Invalid Index";
            }
        }

        /// <summary>
        /// Enumeration of food categories.
        /// </summary>
        public enum FoodCategories { Meat, Vegetable, Fruit, Cereal, Dairy, Nuts }

        /// <summary>
        /// Gets the string representation of the specified food category index.
        /// </summary>
        /// <param name="index">The index representing a food category.</param>
        /// <returns>The string representation of the food category.</returns>
        public static string GetFoodCategoryString(this int index)
        {
            if (Enum.IsDefined(typeof(FoodCategories), index))
            {
                return ((FoodCategories)index).ToString();
            }
            else
            {
                return "Invalid Index";
            }
        }

        /// <summary>
        /// Enumeration of chart period options.
        /// </summary>
        public enum ChartPeriodOptions { ThisWeek, LastWeek, ThisMonth, LastMonth }
    }
}
