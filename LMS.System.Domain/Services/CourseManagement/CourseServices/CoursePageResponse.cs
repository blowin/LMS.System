using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.System.Domain.Services.CourseManagement.Enums;
using LMS.System.Domain.Services.DBServices.Models;

namespace LMS.System.Domain.Services.CourseManagement.CourseServices
{
    /// <summary>
    /// Класс определяющий содержание страницы.
    /// </summary>
    public class CoursePageResponse
    {
        /// <summary>
        /// Идентификатор курса.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок курса.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Описание курса.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Название категории к которому относится курс.
        /// </summary>
        public string? CategoryName { get; set; }

        /// <summary>
        /// Название категории к которому относится курс.
        /// </summary>
        public string? InstructorName { get; set; }
    }
}
