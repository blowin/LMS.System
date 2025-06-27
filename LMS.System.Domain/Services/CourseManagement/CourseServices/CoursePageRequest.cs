using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.System.Domain.Services.CourseManagement.Enums;
using LMS.System.Domain.Services.CourseManagement.Page;

namespace LMS.System.Domain.Services.CourseManagement.CourseServices
{
    /// <summary>
    /// Класс параметров запроса.
    /// </summary>
    public class CoursePageRequest
    {
        /// <summary>
        /// Поиск по ID.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Поисковой запрос для курса.
        /// </summary>
        public string? SearchTerm { get; set; }

        /// <summary>
        /// Поле сортировки.
        /// </summary>
        public EVCourseField SortField { get; set; }

        /// <summary>
        /// Cортировка по возрастанию/убыванию.
        /// </summary>
        public EVSortType SortType { get; set; }

        /// <summary>
        /// Поиск по названию категории.
        /// </summary>
        public string? CategoryName { get; set; }

        /// <summary>
        /// Поиск по уникальному номеру инструктора.
        /// </summary>
        public int? InstructorId { get; set; }

        /// <summary>
        /// Настройки пагинации.
        /// </summary>
        public PageRequest Page { get; set; } = new PageRequest();
    }
}
