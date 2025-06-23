using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.System.Domain.Services.CourseManagement.Interfaces;

namespace LMS.System.Domain.Services.CourseManagement.Page
{
    /// <summary>
    /// Реализация интерфейса IPagedList.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public class PagedList<T> : IPagedList<T>
    {
        /// <summary>
        /// Элементы текущей страницы.
        /// </summary>
        public IEnumerable<T> Items { get; }

        /// <summary>
        /// Текущая страница (начинается с 1).
        /// </summary>
        public int CurrentPage { get; }

        /// <summary>
        /// Количество элементов на странице.
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Общее количество элементов.
        /// </summary>
        public int TotalItems { get; }

        /// <summary>
        /// Общее количество страниц
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Есть ли предыдущая страница?.
        /// </summary>
        public bool HasPreviousPage => CurrentPage > 1;

        /// <summary>
        /// Есть ли следующая страница?.
        /// </summary>
        public bool HasNextPage => CurrentPage < TotalPages;

        /// <summary>
        /// Реализация полей в конструкторе.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalItems"></param>
        public PagedList(IEnumerable<T> items, int currentPage, int pageSize, int totalItems)
        {
            Items = items;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        }
    }
}
