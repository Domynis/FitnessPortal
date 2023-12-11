namespace FitnessPortal.Services
{
	public class BMICalculator
	{
		public static double Calc(double height, double weight)
		{
			var heightInM = height / 100;
			return Math.Round(weight / (heightInM * heightInM), 2);
		}
	}
}
