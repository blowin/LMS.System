using LMS.System.Domain.Services.DBServices.Models.BaseClases;
using LMS.System.Domain.Services.DBServices.Models.Enums;

namespace LMS.System.Domain.Services.DBServices.Models
{
    /// <summary>
    /// User: содержит информацию о пользователях (студенты, преподаватели, админы).
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public required string PasswordHash { get; set; }

        /// <summary>
        /// Роль пользователя(Админ,Преподаватель,Студент).
        /// </summary>
        public EVRole Role { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Отчество пользователя.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Коллекция курсов юзера.
        /// </summary>
        public ICollection<Course> CoursesForUser { get; set; } = new List<Course>();

        /// <summary>
        /// коллекция зачисленных студентов.
        /// </summary>
        public ICollection<Enrollment> EnrollmentForUsers { get; set; } = new List<Enrollment>();

        /// <summary>
        /// коллекция отправленных решений пользователя.
        /// </summary>
        public ICollection<Submission> SubmissionsForUser { get; set; } = new List<Submission>();
    }
}
