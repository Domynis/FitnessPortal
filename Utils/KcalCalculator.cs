namespace FitnessPortal.Utils
{
    /// <summary>
    /// Utility class for calculating total kilocalories based on kilocalories per 100 grams and quantity.
    /// </summary>
    public class KcalCalculator
    {
        /// <summary>
        /// Calculates the total kilocalories based on kilocalories per 100 grams and quantity.
        /// </summary>
        /// <param name="kcalPer100g">Kilocalories per 100 grams of the food item.</param>
        /// <param name="quantity">Quantity of the food item.</param>
        /// <returns>Total kilocalories for the specified quantity of the food item.</returns>
        public static double Calc(double kcalPer100g, double quantity)
        {
            return quantity * kcalPer100g / 100;
        }
    }
}
