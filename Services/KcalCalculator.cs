namespace FitnessPortal.Services
{
	public class KcalCalculator
	{
		public static float Calc(float kcalPer100g, float quantity)
		{
			return (quantity * kcalPer100g) / 100;
		}
	}
}
