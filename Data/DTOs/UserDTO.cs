using FitnessPortal.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace FitnessPortal.Data.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for representing user-related information.
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user details.
        /// </summary>
        public Guid UserDetailsID { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        [Required]
        public int Role { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the gender of the user.
        /// </summary>
        public string? Gender { get; set; }

        /// <summary>
        /// Gets or sets the age of the user.
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Gets or sets the weight of the user.
        /// </summary>
        public double? Weight { get; set; }

        /// <summary>
        /// Gets or sets the height of the user.
        /// </summary>
        public double? Height { get; set; }

        /// <summary>
        /// Gets or sets the BMI (Body Mass Index) of the user.
        /// </summary>
        public double? BMI { get; set; }

        /// <summary>
        /// Gets or sets the KCal goal of the user.
        /// </summary>
        public int? KCalGoal { get; set; }

        /// <summary>
        /// Creates a UserDTO object from a User object.
        /// </summary>
        /// <param name="user">The User object to create the UserDTO from.</param>
        /// <returns>The created UserDTO object.</returns>
        public static UserDTO From(User user)
        {
            return new UserDTO
            {
                UserName = user.UserName,
                Role = user.Role,
                UserID = user.ID,
                FirstName = user.UserDetails.FirstName,
                LastName = user.UserDetails.LastName,
                Age = user.UserDetails.Age,
                Gender = user.UserDetails.Gender,
                Weight = user.UserDetails.Weight,
                Height = user.UserDetails.Height,
                KCalGoal = user.UserDetails.KCalGoal,
                UserDetailsID = user.UserDetails.ID,
            };
        }
    }
}
