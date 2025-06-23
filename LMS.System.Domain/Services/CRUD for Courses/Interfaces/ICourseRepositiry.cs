using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.System.Domain.Services.DBServices.Models;

namespace LMS.System.Domain.Services.CRUD_for_Courses.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория.
    /// </summary>
    public interface ICourseRepository
    {
        /// <summary>
        /// Получение курса по ID.
        /// </summary>
        /// <param name="id">Айдишник курса.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает курс по айдишнику.</returns>
        Task<Course?> GetCourseByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Добавление курса.
        /// </summary>
        /// <param name="course">Передаём курс.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращаем сообщение.</returns>
        Task<Guid> CreateCourseAsync(Course course, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновление курса.
        /// </summary>
        /// <param name="course">Передаём курс.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращаем сообщение.</returns>
        Task UpdateCourseAsync(Course course, CancellationToken cancellationToken = default);

        /// <summary>
        /// Удаление курса.
        /// </summary>
        /// <param name="id">Айдишник курса.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращаем сообщение.</returns>
        Task DeleteCourseAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Публикация курса.
        /// </summary>
        /// <param name="id">Айдишник курса.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращаем сообщение.</returns>
        Task PublishCourseAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Архивирование курса.
        /// </summary>
        /// <param name="id">Айдишник курса.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращаем сообщение.</returns>
        Task ArchiveCourseAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
