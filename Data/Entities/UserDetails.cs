using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPortal.Data.Entities
{
    /// <summary>
    /// Represents additional details of a user in the database.
    /// </summary>
    public class UserDetails
    {
        /// <summary>
        /// Gets or sets the unique identifier for user details.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

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
        /// Gets or sets the daily caloric goal of the user.
        /// </summary>
        public int? KCalGoal { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the associated user.
        /// </summary>
        [ForeignKey("UserID")]
        public Guid UserID { get; set; }

        /// <summary>
        /// Gets or sets the associated user.
        /// </summary>
        public User User { get; set; } = null!;
    }
}
