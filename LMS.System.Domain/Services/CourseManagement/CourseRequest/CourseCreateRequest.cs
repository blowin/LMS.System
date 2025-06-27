using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.System.Domain.Services.CourseManagement.CourseRequest
{
    /// <summary>
    /// Класс для создания курса.
    /// </summary>
    public class CourseCreateRequest
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
        /// Уникальный номер категории.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Уникальный номер преподавателя.
        /// </summary>
        public int InstructorId { get; set; }
    }
}
