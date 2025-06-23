using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.System.Domain.Services.CourseManagement.Page
{
    /// <summary>
    /// Абстрактный класс настройки страницы.
    /// </summary>
    public abstract class PageSettings
    {
        /// <summary>
        /// Максимальное количество записей.
        /// </summary>
        private const int MaxPageSize = 100;

        /// <summary>
        /// Минимальное количество записей.
        /// </summary>
        private int _pageSize = 10;

        /// <summary>
        /// количество страниц.
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Получение количества записей на странице.
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}
