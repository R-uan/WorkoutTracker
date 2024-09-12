using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Database
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : DbContext(context)
	{
		public DbSet<User> User { get; set; }
		public DbSet<Workout> Workout { get; set; }
		public DbSet<Exercise> Exercise { get; set; }
		public DbSet<ExerciseRecord> ExerciseRecord { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Exercise>(ex =>
			{
				ex.ToTable("exercises");
				ex.HasKey(ex => ex.Id);
			});

			modelBuilder.Entity<User>(user =>
			{
				user.ToTable("users");
				user.HasKey(user => user.Id);

				user.HasMany(user => user.Workouts)
				.WithOne(workout => workout.User)
				.HasForeignKey(workout => workout.UserId);
			});

			modelBuilder.Entity<Workout>(work =>
			{
				work.ToTable("workouts");
				work.HasKey(work => work.Id);

				work.HasMany(work => work.ExerciseRecords)
				.WithOne(exercise => exercise.Workout)
				.HasForeignKey(exercise => exercise.WorkoutId);
			});

			modelBuilder.Entity<ExerciseRecord>(er =>
			{
				er.ToTable("exercise_records");
				er.HasKey(er => er.Id);

				er.HasOne(er => er.Exercise)
				.WithMany(e => e.ExerciseRecords)
				.HasForeignKey(er => er.ExerciseId);

				er.HasOne(er => er.Workout)
				.WithMany(work => work.ExerciseRecords)
				.HasForeignKey(er => er.WorkoutId);
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}