using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessPortal.Data.Entities
{
    /// <summary>
    /// Represents user information in the database.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

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
        /// Gets or sets the details of the user.
        /// </summary>
        public UserDetails UserDetails { get; set; }

        /// <summary>
        /// Gets or sets the list of food journals associated with the user.
        /// </summary>
        public List<FoodJournal> FoodJournals { get; set; } = new List<FoodJournal>();

        /// <summary>
        /// Gets or sets the list of sleep journals associated with the user.
        /// </summary>
        public List<SleepJournal> SleepJournals { get; set; } = new List<SleepJournal>();
    }
}
