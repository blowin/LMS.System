using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.System.Domain.Services.CourseManagement.CourseRequest;
using LMS.System.Domain.Services.CourseManagement.CourseServices;
using LMS.System.Domain.Services.CourseManagement.Enums;
using LMS.System.Domain.Services.DBServices.Models;
using X.PagedList;

namespace LMS.System.Domain.Services.CourseManagement.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса.
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Получение страницы курса.
        /// </summary>
        /// <param name="request">Параметры страницы.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Ничего не возвращает.</returns>
        Task<IPagedList<CoursePageResponse>> GetCoursePageAsync(CoursePageRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Получение курса по ID.
        /// </summary>
        /// <param name="id">Айдишник курса.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает курс по айдишнику.</returns>
        Task<Course?> CourseByIdResponse(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавление курса.
        /// </summary>
        /// <param name="request">Передаём курс.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращаем сообщение.</returns>
        Task<int> CreateCourseAsync(CourseCreateRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Обновление курса.
        /// </summary>
        /// <param name="course">Передаём курс.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращаем сохранение изменений.</returns>
        Task UpdateCourseAsync(CourseUpdateRequest course, CancellationToken cancellationToken);

        /// <summary>
        /// Удаление курса.
        /// </summary>
        /// <param name="id">Айдишник курса.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращаем сохранение изменений.</returns>
        Task DeleteCourseAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Публикация курса.
        /// </summary>
        /// <param name="id">Айдишник курса.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращаем сохранение изменений.</returns>
        Task PublishCourseAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Архивирование курса.
        /// </summary>
        /// <param name="id">Айдишник курса.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращаем сохранение изменений.</returns>
        Task ArchiveCourseAsync(int id, CancellationToken cancellationToken);
    }
}
