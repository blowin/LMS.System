using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.System.Domain.Services.CourseManagement.CourseServices;
using LMS.System.Domain.Services.CourseManagement.Interfaces;
using LMS.System.Domain.Services.CourseManagement.Page;
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
        /// Initializes a new instance of the <see cref="CourseService"/> class.
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
        public async Task<IPagedList<CoursePageResponse>> GetCoursePageAsync(CoursePageRequest request, CancellationToken cancellationToken)
        {
            var query = _context.Courses
                .Include(c => c.InstructorId)
                .Include(c => c.CategoryId)
                .AsQueryable();

            var SearchById = _context.Courses
                .FirstOrDefault(c => c.Id == request.SearchById);

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(c =>
                c.Title.Contains(request.SearchTerm) ||
                c.Description.Contains(request.SearchTerm));
            }

            if (request.SearchById > 0)
            {
                query = query.Where(c => c.Id == request.SearchById);
            }

            if (!string.IsNullOrEmpty(request.SearchByCategoryName))
            {
                query = query.Where(c =>
                c.Category != null &&
                c.Category.Name.Contains(request.SearchByCategoryName));
            }

            if (request.SearchByInstructorId > 0)
            {
                query = query.Where(c => c.Id == request.SearchByInstructorId);
            }

            query = request.SortBy?.ToLower() switch
            {
                "title" => request.SortDescending
                    ? query.OrderByDescending(c => c.Title)
                    : query.OrderBy(c => c.Title),

                "category" => request.SortDescending
                    ? query.OrderByDescending(c => c.Category != null ? c.Category.Name : null)
                    : query.OrderBy(c => c.Category != null ? c.Category.Name : null),

                "instructor" => request.SortDescending
                    ? query.OrderByDescending(c => c.Users != null
                        ? $"{c.Users.LastName} {c.Users.FirstName} "
                        : null)
                    : query.OrderBy(c => c.Users != null
                    ? $"{c.Users.LastName} {c.Users.FirstName} "
                        : null),

                "date" => request.SortDescending
                    ? query.OrderByDescending(c => c.CreatedAt)
                    : query.OrderBy(c => c.CreatedAt),

                _ => query.OrderBy(c => c.Id),
            };

            var TotalCount = await query.CountAsync(cancellationToken);

            var items = query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => new CoursePageResponse
                {
                    Id = c.Id,
                    Title = c.Title ?? "Без названия",
                    Description = c.Description ?? "Описание отсутствует",
                    CategoryName = c.Category != null ? c.Category.Name : "Без категории",
                });

            return new PagedList<CoursePageResponse>(items, request.Page, request.PageSize, TotalCount);
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
