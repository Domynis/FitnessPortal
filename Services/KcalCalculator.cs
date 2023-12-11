namespace FitnessPortal.Services
{
	public class KcalCalculator
	{
		public static double Calc(double kcalPer100g, double quantity)
		{
			return (quantity * kcalPer100g) / 100;
		}
	}
}
