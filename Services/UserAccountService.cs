// Importing necessary namespaces for the UserAccountService class
using FitnessPortal.Data;
using FitnessPortal.Data.DTOs;
using FitnessPortal.Data.Entities;
using FitnessPortal.Utils;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace FitnessPortal.Services
{
    /// <summary>
    /// Service class responsible for handling user account-related operations within the Fitness Portal application.
    /// </summary>
    public class UserAccountService : IUserAccountService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAccountService"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public UserAccountService(ApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        /// <summary>
        /// Helper method to add or update a User entity in the database.
        /// </summary>
        /// <param name="user">The User entity to be added or updated.</param>
        /// <returns>The added or updated User entity.</returns>
        private void AddOrUpdateUser(User user)
        {
            // Retrieve the existing user or create a new one

            if (user.ID != Guid.Empty)
            {
                var existingUser = _context.Users.Where(x => x.ID == user.ID).FirstOrDefault();
                if (existingUser != null)
                {
                    existingUser.UserName = user.UserName;
                    existingUser.Password = user.Password;
                    existingUser.Role = user.Role;
                }
                else
                {
                    throw new InvalidDataException("Trying to update user that doesn't exist.");
                }
            }
            else if (_context.Users.Where(x => x.UserName.Equals(user.UserName)).FirstOrDefault() != null)
            {
                throw new InvalidDataException("UserName is not unique! Choose another one!");
            }
            else
            {
                _context.Users.Add(user);
            }

            // Save changes to the database
            _context.SaveChanges();
        }

        /// <summary>
        /// Helper method to add or update a UserDetails entity in the database.
        /// </summary>
        /// <param name="userDetails">The UserDetails entity to be added or updated.</param>
        /// <returns>The added or updated UserDetails entity.</returns>
        private void AddOrUpdateUserDetails(UserDetails userDetails)
        {
            // Retrieve the existing user details or create a new one
            var model = userDetails.ID != Guid.Empty ? _context.UsersDetails.Where(x => x.ID == userDetails.ID).FirstOrDefault() : userDetails;

            // Update the user details properties
            if (userDetails.ID != Guid.Empty)
            {
                var existingUserDetails = _context.UsersDetails.Where(x => x.ID == userDetails.ID).FirstOrDefault();
                if (existingUserDetails != null)
                {
                    existingUserDetails.FirstName = userDetails.FirstName;
                    existingUserDetails.LastName = userDetails.LastName;
                    existingUserDetails.Gender = userDetails.Gender;
                    existingUserDetails.Age = userDetails.Age;
                    existingUserDetails.Weight = userDetails.Weight;
                    existingUserDetails.Height = userDetails.Height;
                    existingUserDetails.BMI = userDetails.BMI;
                    existingUserDetails.KCalGoal = userDetails.KCalGoal;
                }
                else
                {
                    throw new InvalidDataException("Trying to update user details that doesn't exist.");
                }
            }
            else
            {
                _context.UsersDetails.Add(userDetails);
            }

            // Save changes to the database
            _context.SaveChanges();
        }

        // Main method to add or update user information based on the provided UserDTO
        /// <inheritdoc/>
        public void AddOrUpdateUserDTO(UserDTO userDTO)
        {
            // Hash the user's password using SHA256
            using SHA256 sha256Hash = SHA256.Create();
            // Create or update the User entity in the database
            User user = new()
            {
                ID = userDTO.UserID,
                UserName = userDTO.UserName,
                Password = PasswordHasher.GetHash(sha256Hash, userDTO.Password),
                Role = userDTO.Role
            };

            AddOrUpdateUser(user);

            // Create or update the UserDetails entity in the database
            UserDetails userDetails = new()
            {
                ID = userDTO.UserDetailsID,
                User = user,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Gender = userDTO.Gender,
                Age = userDTO.Age,
                Weight = userDTO.Weight,
                Height = userDTO.Height,
                BMI = (userDTO.Weight != null && userDTO.Height != null) ? BMICalculator.Calc(userDTO.Height ?? 0, userDTO.Weight ?? 0) : 0,
                KCalGoal = userDTO.KCalGoal
            };
            AddOrUpdateUserDetails(userDetails);
        }

        // Method to asynchronously retrieve detailed information about a user
        /// <inheritdoc/>
        public async Task<User?> GetUserDetails(Guid userID)
        {
            // Retrieve the user entity including user details from the database
            var dbUser = await _context.Users.Include(x => x.UserDetails).FirstOrDefaultAsync(x => x.ID == userID);
            return dbUser;
        }

        // Method to retrieve a UserDTO object based on the provided user ID
        /// <inheritdoc/>
        public UserDTO? GetUserDTO(Guid ID)
        {
            // Retrieve the User entity including user details based on the user ID
            var result = _context.Users.Include(x => x.UserDetails).FirstOrDefault(x => x.ID == ID);
            return result != null ? UserDTO.From(result) : null;
        }

        // Method to asynchronously authenticate a user by performing a login operation
        /// <inheritdoc/>
        public async Task<User?> Login(User user)
        {
            // Hash the provided password and check for a matching user in the database
            using SHA256 sha256Hash = SHA256.Create();
            var dbUser = await _context.Users.FirstOrDefaultAsync(
                x => x.UserName == user.UserName &&
                x.Password.Equals(PasswordHasher.GetHash(sha256Hash, user.Password)));
            return dbUser;
        }
    }
}
