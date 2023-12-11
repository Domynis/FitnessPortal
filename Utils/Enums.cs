namespace FitnessPortal.Utils
{
    public static class Enums
    {
        public enum Roles { User, Admin }

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

		public enum FoodCategories { Meat, Vegetable, Fruit, Cereal, Dairy, Nuts}

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

		public enum ChartPeriodOptions { ThisWeek, LastWeek, ThisMonth, LastMonth}
	}
}
