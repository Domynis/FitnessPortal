namespace FitnessPortal.Utils
{
    public static class Enums
    {
        public enum Roles { Admin, User }

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
	}
}
