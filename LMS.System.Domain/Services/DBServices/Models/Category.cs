using LMS.System.Domain.Services.DBServices.Models.BaseClases;

namespace LMS.System.Domain.Services.DBServices.Models
{
    /// <summary>
    /// Category: категории курсов (например, "Программирование", "Маркетинг").
    /// </summary>
    public class Category : Entity
    {
        /// <summary>
        /// Название категорий.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Коллекция курсов относящихся к определенной категории.
        /// </summary>
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
