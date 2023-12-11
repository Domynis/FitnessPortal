using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPortal.Data.Entities
{
    /// <summary>
    /// Represents sleep journal information in the database.
    /// </summary>
    public class SleepJournal
    {
        /// <summary>
        /// Gets or sets the unique identifier for the sleep journal entry.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the start time of the sleep.
        /// </summary>
        [Required]
        public DateTime From { get; set; }

        /// <summary>
        /// Gets or sets the end time of the sleep.
        /// </summary>
        [Required]
        public DateTime To { get; set; }

        /// <summary>
        /// Gets or sets the date of the sleep journal entry.
        /// </summary>
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the user ID associated with the sleep journal entry.
        /// </summary>
        [ForeignKey("UserID")]
        public Guid UserID { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the sleep journal entry.
        /// </summary>
        public User User { get; set; } = null!;
    }
}
