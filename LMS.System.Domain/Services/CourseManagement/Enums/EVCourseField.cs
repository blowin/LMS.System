using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.System.Domain.Services.CourseManagement.Enums
{
    /// <summary>
    /// Enum для полей курса, по которым будет производиться сортировка.
    /// </summary>
    [Flags]
    public enum EVCourseField
    {
        /// <summary>
        /// Нулевое значение.
        /// </summary>
        Id = 0,

        /// <summary>
        /// Название курса.
        /// </summary>
        Title = 1 << 0,

        /// <summary>
        /// Категория курса.
        /// </summary>
        Category = 1 << 1,
    }
}
