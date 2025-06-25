using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.System.Domain.Services.CourseManagement.Page;

namespace LMS.System.Domain.Services.CourseManagement.CourseServices
{
    /// <summary>
    /// Класс параметров запроса.
    /// </summary>
    public class CoursePageRequest : PageSettings
    {
        /// <summary>
        /// Поиск по ID.
        /// </summary>
        public int SearchById { get; set; }

        /// <summary>
        /// Поисковой запрос для курса.
        /// </summary>
        public string? SearchTerm { get; set; }

        /// <summary>
        /// Поиск по названию категории.
        /// </summary>
        public string? SearchByCategoryName { get; set; }

        /// <summary>
        /// Поиск по уникальному номеру инструктора.
        /// </summary>
        public int SearchByInstructorId { get; set; }

        /// <summary>
        /// Сортировать по.
        /// </summary>
        public string? SortBy { get; set; }

        /// <summary>
        /// Сортировка по убыванию.
        /// </summary>
        public bool SortDescending { get; set; }
    }
}
