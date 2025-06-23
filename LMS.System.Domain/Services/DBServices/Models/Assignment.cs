using LMS.System.Domain.Services.DBServices.Models.BaseClases;
using LMS.System.Domain.Services.DBServices.Models.Enums;

namespace LMS.System.Domain.Services.DBServices.Models
{
    /// <summary>
    /// Assignment: задание, связанное с уроком или курсом.
    /// </summary>
    public class Assignment : Entity
    {
        /// <summary>
        /// Заголовок названия.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание задания.
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Сроки выполнения задания.
        /// </summary>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Поле связывающее задание и курс.
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Тип задания Test, FileUpload , Text.
        /// </summary>
        public EVAssignmentType AssignmentType { get; set; }

        /// <summary>
        /// навигационное свойство для курсов.
        /// </summary>
        public Course? CourseForAssignment { get; set; }

        /// <summary>
        /// коллекция ответов на задание.
        /// </summary>
        public ICollection<Submission> SubmissionsInAssignment { get; set; } = new List<Submission>();

        /// <summary>
        /// Коллекция тестовых вопросов в задании.
        /// </summary>
        public ICollection<TestQuestion> TestQuestionsInAssignment { get; set; } = new List<TestQuestion>();
    }
}
