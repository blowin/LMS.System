using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.System.Domain.Services.DBServices.Models.Enums
{
    /// <summary>
    /// Роли юзера.
    /// </summary>
    public enum EVRole
    {
        /// <summary>
        /// Роль админ.
        /// </summary>
        Admin,

        /// <summary>
        /// Роль преподаватель.
        /// </summary>
        Teacher,

        /// <summary>
        /// Роль студент.
        /// </summary>
        Student,
    }
}
