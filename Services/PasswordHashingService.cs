using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using FitnessPortal.Utils;


namespace FitnessPortal.Services
{
	public class PasswordHashingService
	{
		public string GeneratePasswordHash(string password, byte[] salt)
		{
			var iterations = 10000; // Recommended number of iterations for PBKDF2

			var hash = KeyDerivation.Pbkdf2(
				password,
				salt,
				KeyDerivationPrf.HMACSHA512,
				iterationCount: iterations,
				512);

			return Convert.ToBase64String(hash);
		}

		public byte[] GenerateSalt()
		{
			byte[] salt = new byte[128];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(salt);
			}

			return salt;
		}

		public bool VerifyPasswordHash(string password, string storedHash, byte[] salt)
		{
			var hash = Convert.FromBase64String(storedHash);

			var iterations = 10000; // Same iterations used for hashing

			var newHash = KeyDerivation.Pbkdf2(
				password,
				salt,
				KeyDerivationPrf.HMACSHA512,
				iterationCount: iterations,
				512);

			return SecurityUtils.ConstantTimeEquals(hash, newHash);
		}
	}
}
