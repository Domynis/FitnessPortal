namespace FitnessPortal.Utils
{
	public static class SecurityUtils
	{
		public static bool ConstantTimeEquals(byte[] a, byte[] b)
		{
			if (a == null || b == null || a.Length != b.Length)
			{
				return false;
			}

			int result = 0;

			for (int i = 0; i < a.Length; i++)
			{
				result |= a[i] ^ b[i];
			}

			return result == 0;
		}
	}
}
