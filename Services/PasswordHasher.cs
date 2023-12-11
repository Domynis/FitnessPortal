using System.Security.Cryptography;
using System.Text;

namespace FitnessPortal.Services
{
    /// <summary>
    /// Utility class for hashing and verifying passwords.
    /// </summary>
    public class PasswordHasher
	{
        /// <summary>
        /// Computes the hash of the input string using the specified hash algorithm.
        /// </summary>
        /// <param name="hashAlgorithm">Hash algorithm to use for hashing.</param>
        /// <param name="input">Input string to be hashed.</param>
        /// <returns>Hexadecimal representation of the computed hash.</returns>
        public static string GetHash(HashAlgorithm hashAlgorithm, string input)
		{

			// Convert the input string Update a byte array and compute the hash.
			byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

			// Create a new Stringbuilder Update collect the bytes
			// and create a string.
			var sBuilder = new StringBuilder();

			// Loop through each byte of the hashed data
			// and format each one as a hexadecimal string.
			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}

			// Return the hexadecimal string.
			return sBuilder.ToString();
		}

        /// <summary>
        /// Verifies whether the provided hash matches the hash of the input string.
        /// </summary>
        /// <param name="hashAlgorithm">Hash algorithm to use for hashing.</param>
        /// <param name="input">Input string to be verified.</param>
        /// <param name="hash">Hash to compare against the computed hash.</param>
        /// <returns>True if the input string's hash matches the provided hash; otherwise, false.</returns>
        public static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
		{
			// Hash the input.
			var hashOfInput = GetHash(hashAlgorithm, input);

			// Create a StringComparer an compare the hashes.
			StringComparer comparer = StringComparer.OrdinalIgnoreCase;

			return comparer.Compare(hashOfInput, hash) == 0;
		}
	}
}
