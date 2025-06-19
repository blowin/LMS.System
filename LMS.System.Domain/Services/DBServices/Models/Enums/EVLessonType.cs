using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.System.Domain.Services.DBServices.Models.Enums
{
    /// <summary>
    /// Тип урока Text/Video/PDF.
    /// </summary>
    public enum EVLessonType
    {
        /// <summary>
        /// Текстовый урок.
        /// </summary>
        Text,

        /// <summary>
        /// Видео урок.
        /// </summary>
        Video,

        /// <summary>
        /// Урок в формате PDF.
        /// </summary>
        PDF,
    }
}
