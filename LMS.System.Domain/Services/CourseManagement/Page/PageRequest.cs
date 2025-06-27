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
    public sealed class PageRequest
    {
        /// <summary>
        /// Максимальное количество записей на странице.
        /// </summary>
        private const int MaxPageSize = 100;

        /// <summary>
        /// Минимальное количество записей на странице.
        /// </summary>
        private const int MinPageSize = 1;

        private int _pageSize = 10;
        private int _pageCount = 1;

        /// <summary>
        /// Количество страниц. Должно быть не меньше 1.
        /// </summary>
        public int PageNumber
        {
            get => _pageCount;
            set => _pageCount = value >= 1
                ? value
                : throw new ArgumentOutOfRangeException(nameof(value), "Количество страниц не может быть меньше 1");
        }

        /// <summary>
        /// Количество записей на странице. Ограничено MinPageSize и MaxPageSize.
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value switch
            {
                > MaxPageSize => throw new ArgumentOutOfRangeException(nameof(value), $"Размер страницы не может превышать {MaxPageSize}"),
                < MinPageSize => throw new ArgumentOutOfRangeException(nameof(value), $"Размер страницы не может быть меньше {MinPageSize}"),
                _ => value,
            };
        }
    }
}
