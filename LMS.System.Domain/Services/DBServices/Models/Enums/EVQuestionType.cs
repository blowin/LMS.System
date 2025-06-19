using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.System.Domain.Services.DBServices.Models.Enums
{
    /// <summary>
    /// Типы вопроса.
    /// </summary>
    public enum EVQuestionType
    {
        /// <summary>
        /// Один вариант ответа верный.
        /// </summary>
        SingleChoice,

        /// <summary>
        /// Несколько вариантов ответа верны.
        /// </summary>
        MultiChoice,
    }
}
