using FitnessPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDetails> UsersDetails { get; set; }
        public virtual DbSet<FoodNutrition> FoodsNutrition { get; set; }
        public virtual DbSet<FoodJournal> FoodsJournal { get; set; }
        public virtual DbSet<SleepJournal> SleepJournal { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

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
