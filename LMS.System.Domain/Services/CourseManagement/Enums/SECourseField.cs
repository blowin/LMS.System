using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.SmartEnum;
using LMS.System.Domain.Services.DBServices.Models;

namespace LMS.System.Domain.Services.CourseManagement.Enums
{
    /// <summary>
    /// .
    /// </summary>
    public abstract class SECourseField : SmartEnum<SECourseField, int>
    {
        /// <summary>
        /// .
        /// </summary>
        public static readonly SECourseField Title = new TitleField();

        /// <summary>
        /// .
        /// </summary>
        public static readonly SECourseField Category = new CategoryField();

        /// <summary>
        /// Initializes a new instance of the <see cref="SECourseField"/> class.
        /// </summary>
        /// <param name="value">Send a context.</param>
        public SECourseField(EVCourseField value)
            : base(value.ToString(), (int)value)
        {
        }

        /// <summary>
        /// Конвертация из Enum в int.
        /// </summary>
        /// <param name="value">Значение enum.</param>
        /// <returns>Интовое значение enum value.</returns>
        public SECourseField FromEnum(EVCourseField value) => FromValue((int)value);

        /// <summary>
        /// Сортировка курса.
        /// </summary>
        /// <param name="query">Курсы.</param>
        /// <param name="sortType">Тип сортировки.</param>
        /// <returns>Отсортированный список.</returns>
        public abstract IQueryable<Course> OrderBy(IQueryable<Course> query, EVSortType sortType);

        private sealed class TitleField : SECourseField
        {
            public TitleField()
                : base(EVCourseField.Title)
            {
            }

            public override IQueryable<Course> OrderBy(IQueryable<Course> query, EVSortType sortType)
                => sortType == EVSortType.Asc ? query.OrderBy(e => e.Title) : query.OrderByDescending(e => e.Title);
        }

        private sealed class CategoryField : SECourseField
        {
            public CategoryField()
                : base(EVCourseField.Category)
            {
            }

            public override IQueryable<Course> OrderBy(IQueryable<Course> query, EVSortType sortType)
                => sortType == EVSortType.Asc ? query.OrderBy(e => e.Category) : query.OrderByDescending(e => e.Category);
        }
    }
}
