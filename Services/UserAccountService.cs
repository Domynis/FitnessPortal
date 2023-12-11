// Importing necessary namespaces for the UserAccountService class
using FitnessPortal.Data;
using FitnessPortal.Data.DTOs;
using FitnessPortal.Data.Entities;
using FitnessPortal.Services;
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
        private User AddOrUpdateUser(User user)
        {
            // Retrieve the existing user or create a new one
            var model = user.ID != Guid.Empty ? _context.Users.Where(x => x.ID == user.ID).FirstOrDefault() : user;

            // Update the user properties
            if (model?.ID != Guid.Empty)
            {
                model.UserName = user.UserName;
                model.Password = user.Password;
                model.Role = user.Role;
            }
            else
            {
                _context.Users.Add(model);
            }

            // Save changes to the database
            _context.SaveChanges();
            return model;
        }

        /// <summary>
        /// Helper method to add or update a UserDetails entity in the database.
        /// </summary>
        /// <param name="userDetails">The UserDetails entity to be added or updated.</param>
        /// <returns>The added or updated UserDetails entity.</returns>
        private UserDetails AddOrUpdateUserDetails(UserDetails userDetails)
        {
            // Retrieve the existing user details or create a new one
            var model = userDetails.ID != Guid.Empty ? _context.UsersDetails.Where(x => x.ID == userDetails.ID).FirstOrDefault() : userDetails;

            // Update the user details properties
            if (model.ID != Guid.Empty)
            {
                model.FirstName = userDetails.FirstName;
                model.LastName = userDetails.LastName;
                model.Gender = userDetails.Gender;
                model.Age = userDetails.Age;
                model.Weight = userDetails.Weight;
                model.Height = userDetails.Height;
                model.BMI = userDetails.BMI;
                model.KCalGoal = userDetails.KCalGoal;
            }
            else
            {
                _context.UsersDetails.Add(model);
            }

            // Save changes to the database
            _context.SaveChanges();
            return model;
        }

        // Main method to add or update user information based on the provided UserDTO
        /// <inheritdoc/>
        public void AddOrUpdateUserDTO(UserDTO userDTO)
        {
            // Hash the user's password using SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                userDTO.Password = PasswordHasher.GetHash(sha256Hash, userDTO.Password);
            }

            // Create or update the User entity in the database
            User user = new()
            {
                ID = userDTO.UserID,
                UserName = userDTO.UserName,
                Password = userDTO.Password,
                Role = userDTO.Role
            };
            var modelUser = AddOrUpdateUser(user);

            // Create or update the UserDetails entity in the database
            UserDetails userDetails = new()
            {
                ID = userDTO.UserDetailsID,
                UserID = modelUser.ID,
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
        public async Task<User?> GetUserDetails(User user)
        {
            // Retrieve the user entity including user details from the database
            var dbUser = await _context.Users.Include(x => x.UserDetails).FirstOrDefaultAsync(x => x.ID == user.ID);
            return dbUser;
        }

        // Method to retrieve a UserDTO object based on the provided user ID
        /// <inheritdoc/>
        public UserDTO? GetUserDTO(Guid ID)
        {
            // Retrieve the User entity including user details based on the user ID
            var result = _context.Users.Include(x => x.UserDetails).FirstOrDefault(x => x.ID == ID);
            return UserDTO.From(result);
        }

        // Method to asynchronously authenticate a user by performing a login operation
        /// <inheritdoc/>
        public async Task<User?> Login(User user)
        {
            // Hash the provided password and check for a matching user in the database
            using (SHA256 sha256Hash = SHA256.Create())
            {
                var dbUser = await _context.Users.FirstOrDefaultAsync(
                    x => x.UserName == user.UserName &&
                    x.Password.Equals(PasswordHasher.GetHash(sha256Hash, user.Password)));
                return dbUser;
            }
        }
    }
}
