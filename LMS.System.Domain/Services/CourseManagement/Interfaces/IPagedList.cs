using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.System.Domain.Services.CourseManagement.Interfaces
{
    /// <summary>
    /// Текущие параметры страницы.
    /// </summary>
    /// <typeparam name="T">Шаблон для всех страниц.</typeparam>
    public interface IPagedList<out T>
    {
        /// <summary>
        /// Текущая страница.
        /// </summary>
        int CurrentPage { get; }

        /// <summary>
        /// Количество элементов на странице.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Общее количество страниц.
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Общее количество элементов.
        /// </summary>
        int TotalItems { get; }

        /// <summary>
        /// Имеется ли предыдущая страница.
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Есть ли следующая страница.
        /// </summary>
        bool HasNextPage { get; }

        /// <summary>
        /// Данные текущей страницы.
        /// </summary>
        IEnumerable<T> Items { get; }
    }
}
