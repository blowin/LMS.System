using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.System.Domain.Services.DBServices.Models.Interfaces
{
    /// <summary>
    /// Интерфейс для CreatedAt и UpdatedAt.
    /// </summary>
    public interface IAuditableEntity
    {
        /// <summary>
        /// Поле CreatedAt.
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Поле UpdatedAt.
        /// </summary>
        DateTime UpdatedAt { get; set; }
    }
}
