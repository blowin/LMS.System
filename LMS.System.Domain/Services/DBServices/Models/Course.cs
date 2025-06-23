using LMS.System.Domain.Services.DBServices.Models.BaseClases;

namespace LMS.System.Domain.Services.DBServices.Models
{
    /// <summary>
    /// Course: представляет собой учебный курс.
    /// </summary>
    public class Course : Entity
    {
        /// <summary>
        /// Заголовок дисциплины.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание дисциплины.
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Уникальный номер категории(связть О-M).
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Уникальный номер преподавателя (подумать связь).
        /// </summary>
        public int InstructorId { get; set; }

        /// <summary>
        /// Поле хранящее информацию о состоянии дисциплины(скрыто/доступно).
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        /// Навигационное свойство для юзера.
        /// </summary>
        public User? Users { get; set; }

        /// <summary>
        /// Навигационное свойство для Category.
        /// </summary>
        public Category? Category { get; set; }

        /// <summary>
        /// коллекция зачисленных на курс.
        /// </summary>
        public ICollection<Enrollment> EnrollmentInCourse { get; set; } = new List<Enrollment>();

        /// <summary>
        /// коллекция уроков в курсе.
        /// </summary>
        public ICollection<Lesson> LessonsInCourse { get; set; } = new List<Lesson>();

        /// <summary>
        /// Коллекция заданий в курсе.
        /// </summary>
        public ICollection<Assignment> AssignmentsInCourse { get; set; } = new List<Assignment>();
    }
}
