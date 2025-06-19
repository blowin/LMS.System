using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.System.Domain.Services.DBServices.Models.Enums
{
    /// <summary>
    /// Определяет тип задания Test, FileUpload , Text.
    /// </summary>
    public enum EVAssignmentType
    {
        /// <summary>
        /// Тип задания тест.
        /// </summary>
        Test,

        /// <summary>
        /// Тип задания Загрузка файла.
        /// </summary>
        FileUpload,

        /// <summary>
        /// Текстовый тип задания.
        /// </summary>
        Text,
    }
}
