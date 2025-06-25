using LMS.System.Domain.Services.DBServices.Models.BaseClases;
using LMS.System.Domain.Services.DBServices.Models.Enums;

namespace LMS.System.Domain.Services.DBServices.Models
{
    /// <summary>
    /// Lesson: урок внутри курса.
    /// </summary>
    public class Lesson : Entity
    {
        /// <summary>
        /// Заголовой урока.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Содержание урока.
        /// </summary>
        public required string Content { get; set; }

        /// <summary>
        /// Поле для пути к PDF файлу.
        /// </summary>
        public string? FilePDFPath { get; set; }

        /// <summary>
        /// Поле для пути к Видео файлу.
        /// </summary>
        public string? MoviesPath { get; set; }

        /// <summary>
        /// Уникальный номер курса.
        /// Связывает урок и курс.
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Порядковый номер урока в курсе.
        /// Это значение определяет последовательность уроков при их выводе.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Получает или задает тип урока.
        /// Допустимые значения: <see cref="LessonType.Text"/>, <see cref="LessonType.Video"/>, <see cref="LessonType.PDF"/>.
        /// </summary>
        public EVLessonType LessonType { get; set; }

        /// <summary>
        /// навигационное свойство для курсов.
        /// </summary>
        public Course? CourseForLesson { get; set; }
    }
}
