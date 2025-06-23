using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.System.Domain.Services.CourseManagement.CourseServices;
using LMS.System.Domain.Services.CourseManagement.Interfaces;
using LMS.System.Domain.Services.DBServices.DBContext;
using LMS.System.Domain.Services.DBServices.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.System.Domain.Services.CourseManagement.Repository
{
    /// <summary>
    /// Реализация ICourseRepository.
    /// </summary>
    public class CourseService : ICourseService
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// Constructor which get a context.
        /// </summary>
        /// <param name="context">Send a context.</param>
        public CourseService(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Реализация метода получения страниц курсов.
        /// </summary>
        /// <param name="request">Параметры фильтрации.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращаем страницы.</returns>
        public Task<IPagedList<CoursePageResponse>> GetCoursePageAsync(CoursePageRequest request, CancellationToken cancellationToken)
        {
            return; 
        }

        /// <summary>
        /// Получение курса по ID.
        /// </summary>
        /// <param name="id">ID курса.</param>
        /// <param name="cancellationToken">Токен отмены действия.</param>
        /// <returns>Возвращает найденный курс.</returns>
        public async Task<Course?> GetCourseByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Courses.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        /// <summary>
        /// Создание курса.
        /// </summary>
        /// <param name="course">Передаём курс.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращаем ID созданного курса.</returns>
        public async Task<int> CreateCourseAsync(Course course, CancellationToken cancellationToken)
        {
            await _context.Courses.AddAsync(course, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return course.Id;
        }

        /// <summary>
        /// Метод изменения курса.
        /// </summary>
        /// <param name="course">Передаём курс.</param>
        /// <param name="cancellationToken">Токуен отмены.</param>
        /// <returns>Возвращаем сохранение изменений.</returns>
        public async Task UpdateCourseAsync(Course course, CancellationToken cancellationToken)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Метод удаления курса.
        /// </summary>
        /// <param name="id">ID курса.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Ничего.</returns>
        public async Task DeleteCourseAsync(int id, CancellationToken cancellationToken)
        {
            var course = await GetCourseByIdAsync(id, cancellationToken);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        /// <summary>
        /// Метод публикации курса.
        /// </summary>
        /// <param name="id">ID курса.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Ничего не возвращаем.</returns>
        public async Task PublishCourseAsync(int id, CancellationToken cancellationToken)
        {
            var course = await GetCourseByIdAsync(id, cancellationToken);
            if (course != null)
            {
                course.IsPublished = true;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        /// <summary>
        /// Архивация курса.
        /// </summary>
        /// <param name="id">ID курса.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Ничего не возвращаем.</returns>
        public async Task ArchiveCourseAsync(int id, CancellationToken cancellationToken)
        {
            var course = await GetCourseByIdAsync(id, cancellationToken);
            if (course != null)
            {
                course.IsArchive = true;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
