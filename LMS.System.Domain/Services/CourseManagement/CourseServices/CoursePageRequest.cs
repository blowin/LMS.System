using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int SearchById { get; set; }

        /// <summary>
        /// Номер страницы.
        /// </summary>
        public int Page { get; set; } = 1;

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
