using System;

namespace FitnessPortal.Services
{
    /// <summary>
    /// Provides methods for calculating Body Mass Index (BMI).
    /// </summary>
    public class BMICalculator
    {
        /// <summary>
        /// Calculates the Body Mass Index (BMI) based on the given height and weight.
        /// </summary>
        /// <param name="height">The height in centimeters.</param>
        /// <param name="weight">The weight in kilograms.</param>
        /// <returns>The calculated BMI.</returns>
        public static double Calc(double height = 0, double weight = 0)
        {
            if (height <= 0 || weight <= 0)
            {
                throw new ArgumentException("Height and weight must be positive values.");
            }

            var heightInMeters = height / 100;
            return Math.Round(weight / (heightInMeters * heightInMeters), 2);
        }
    }
}
