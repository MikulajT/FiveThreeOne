using FiveThreeOne.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FiveThreeOne.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<MainExercise> MainExercises { get; set; }
        public DbSet<MainExerciseSet> MainExerciseSets { get; set; }
        public DbSet<AssistanceExercise> AssistanceExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // This applies configurations from the current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
