namespace FitnessPortal.Services
{
	public class BMICalculator
	{
		public static float Calc(float height, float weight)
		{
			var heightInM = height / 100;
			return (float)Math.Round(weight / (heightInM * heightInM), 2);
		}
	}
}
