using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.System.Domain.Services.CourseManagement.CourseRequest
{
    /// <summary>
    /// Класс для обновления курса.
    /// </summary>
    public class CourseUpdateRequest
    {
        /// <summary>
        /// Идентификатор курса.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок дисциплины.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Описание дисциплины.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Доступность курса.
        /// </summary>
        public bool? IsPublished { get; set; }
    }
}
