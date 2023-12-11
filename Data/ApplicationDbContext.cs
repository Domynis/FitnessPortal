using FitnessPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessPortal.Data
{
    /// <summary>
    /// Represents the database context for the Fitness Portal application.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class with the specified options.
        /// </summary>
        /// <param name="options">The options to be used by the context.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet for users in the database.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for user details in the database.
        /// </summary>
        public virtual DbSet<UserDetails> UsersDetails { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for food nutrition in the database.
        /// </summary>
        public virtual DbSet<FoodNutrition> FoodsNutrition { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for food journal entries in the database.
        /// </summary>
        public virtual DbSet<FoodJournal> FoodsJournal { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for sleep journal entries in the database.
        /// </summary>
        public virtual DbSet<SleepJournal> SleepJournal { get; set; }
        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        /// <inheritdoc/>
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            if (configurationBuilder == null)
            {
                throw new ArgumentNullException(nameof(configurationBuilder));
            }

            base.ConfigureConventions(configurationBuilder);
        }
    }
}
