using LMS.System.Domain.Services.DBServices.Models;
using LMS.System.Domain.Services.DBServices.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Internal;

namespace LMS.System.Domain.Services.DBServices.DBContext
{
    /// <summary>
    /// Контекст для работы с бд.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by this context.</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            SavingChanges += OnSavingChanges;
        }

        /// <summary>
        /// Поле хранящее текущее время.
        /// </summary>
        public ISystemClock Clock { get; set; } = new SystemClock();

        /// <summary>
        /// Инициализация таблицы Users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Инициализация таблицы Categories.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Инициализация таблицы Courses.
        /// </summary>
        public DbSet<Course> Courses { get; set; }

        /// <summary>
        /// Инициализация таблицы Enrollments.
        /// </summary>
        public DbSet<Enrollment> Enrollments { get; set; }

        /// <summary>
        /// Инициализация таблицы Lessons.
        /// </summary>
        public DbSet<Lesson> Lessons { get; set; }

        /// <summary>
        /// Инициализация таблицы Assignments.
        /// </summary>
        public DbSet<Assignment> Assignments { get; set; }

        /// <summary>
        /// Инициализация таблицы Submissions.
        /// </summary>
        public DbSet<Submission> Submissions { get; set; }

        /// <summary>
        /// Инициализация таблицы TestQuestions.
        /// </summary>
        public DbSet<TestQuestion> TestQuestions { get; set; }

        /// <summary>
        /// Инициализация таблицы TestSubmissions.
        /// </summary>
        public DbSet<TestSubmission> TestSubmissions { get; set; }

        /// <summary>
        /// Инициализация таблицы TestAnswerOptions.
        /// </summary>
        public DbSet<TestAnswerOption> TestAnswerOptions { get; set; }

        /// <summary>
        /// реализация метода срабатывающего при создании моделей.
        /// </summary>
        /// <param name="modelBuilder">конструктор моделей.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>(e =>
            {
                e.Property(e => e.LessonType).HasEnumComment();
            });

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Метод сохранения изменений.
        /// </summary>
        private void OnSavingChanges(object? sender, SaveChangesEventArgs e)
        {
            var now = Clock.UtcNow.UtcDateTime;
            foreach (var entity in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        if (entity.Entity.CreatedAt == default)
                        {
                            entity.Entity.CreatedAt = now;
                        }

                        entity.Entity.UpdatedAt = now;
                        break;
                    case EntityState.Modified:
                        entity.Entity.UpdatedAt = now;
                        break;
                }
            }
        }
    }
}
