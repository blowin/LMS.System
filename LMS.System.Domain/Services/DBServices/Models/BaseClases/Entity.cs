using LMS.System.Domain.Services.DBServices.Models.Interfaces;

namespace LMS.System.Domain.Services.DBServices.Models.BaseClases
{
    /// <summary>
    /// Базовый абстрактный класс.
    /// </summary>
    public abstract class Entity : IAuditableEntity
    {
        /// <summary>
        /// Базовое поле Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Базовое поле CreatedAt.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Базовое поле UpdatedAt.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
