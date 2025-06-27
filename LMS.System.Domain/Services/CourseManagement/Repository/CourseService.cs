using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.SmartEnum;
using FluentValidation;
using LMS.System.Domain.Services.CourseManagement.CourseRequest;
using LMS.System.Domain.Services.CourseManagement.CourseServices;
using LMS.System.Domain.Services.CourseManagement.Enums;
using LMS.System.Domain.Services.CourseManagement.Interfaces;
using LMS.System.Domain.Services.CourseManagement.Page;
using LMS.System.Domain.Services.CourseManagement.Validator;
using LMS.System.Domain.Services.DBServices.DBContext;
using LMS.System.Domain.Services.DBServices.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

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
                .Include(c => c.Users)
                .Include(c => c.Category)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.Trim();
                query = query.Where(c =>
                    c.Title.Contains(searchTerm) ||
                    c.Description.Contains(searchTerm));
            }

            if (request.Id > 0)
            {
                query = query.Where(c => c.Id == request.Id);
            }

            if (!string.IsNullOrWhiteSpace(request.CategoryName))
            {
                var SearchByCategoryName = request.CategoryName.Trim();
                query = query.Where(c =>
                    c.Category != null &&
                    c.Category.Name.Contains(SearchByCategoryName));
            }

            if (request.InstructorId > 0)
            {
                query = query.Where(c =>
                    c.InstructorId == request.InstructorId);
            }

            var sortField = SECourseField.FromValue((int)request.SortField) ?? SECourseField.Id;
            query = sortField.OrderBy(query, request.SortType);

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .Select(c => new CoursePageResponse
                {
                    Id = c.Id,
                    Title = c.Title != null ? c.Title : null,
                    Description = c.Description != null ? c.Description : null,
                    CategoryName = c.Category != null ? c.Category.Name : null,
                    InstructorName = c.Users != null ? c.Users.FirstName : null,
                })
                .ToListAsync(cancellationToken);

            var pagedList = await items.ToPagedListAsync(
                request.Page.PageNumber,
                request.Page.PageSize,
                cancellationToken);

            return pagedList;
        }

        /// <summary>
        /// Получение курса по ID.
        /// </summary>
        /// <param name="id">ID курса.</param>
        /// <param name="cancellationToken">Токен отмены действия.</param>
        /// <returns>Возвращает найденный курс.</returns>
        public async Task<Course?> CourseByIdResponse(int id, CancellationToken cancellationToken)
        {
            return await _context.Courses.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        /// <summary>
        /// Создание курса.
        /// </summary>
        /// <param name="request">Передаём курс.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращаем ID созданного курса.</returns>
        public async Task<int> CreateCourseAsync(CourseCreateRequest request, CancellationToken cancellationToken)
        {
            var validator = new CourseCreateRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var course = new Course
            {
                Title = request.Title,
                Description = request.Description,
                CategoryId = request.CategoryId,
                InstructorId = request.InstructorId,
            };
            try
            {
                await _context.Courses.AddAsync(course, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return course.Id;
            }
            catch (DbException ex)
            {
                Trace.TraceError($"Error occurred: {ex}");
                return 0;
            }
        }

        /// <summary>
        /// Метод изменения курса.
        /// </summary>
        /// <param name="request">Передаём курс.</param>
        /// <param name="cancellationToken">Токуен отмены.</param>
        /// <returns>Возвращаем сохранение изменений.</returns>
        public async Task UpdateCourseAsync(CourseUpdateRequest request, CancellationToken cancellationToken)
        {
            var validator = new CourseUpdateRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                throw new ValidationException(string.Join("\n", errorMessages));
            }

            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (course == null)
            {
                throw new ArgumentException($"Course with ID {request.Id} not found", nameof(request.Id));
            }

            if (request.Title != null)
            {
                course.Title = request.Title;
            }

            if (request.Description != null)
            {
                course.Description = request.Description;
            }

            if (request.IsPublished.HasValue)
            {
                course.IsPublished = request.IsPublished.Value;
            }

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch
            (DbUpdateException ex)
            {
                Trace.TraceError($"Error occurred: {ex}");
                throw new InvalidOperationException("Update is faill. Check your data and try again.", ex);
            }
        }

        /// <summary>
        /// Метод удаления курса.
        /// </summary>
        /// <param name="id">ID курса.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Ничего.</returns>
        public async Task DeleteCourseAsync(int id, CancellationToken cancellationToken)
        {
            bool exists = await _context.Courses
                .AnyAsync(c => c.Id == id, cancellationToken);

            if (!exists)
            {
                throw new KeyNotFoundException($"Курс с ID {id} не найден");
            }

            try
            {
                await _context.Courses
                      .Where(c => c.Id == id)
                      .ExecuteDeleteAsync(cancellationToken);
            }
            catch (DbException ex)
            {
                Trace.TraceError($"Error occurred: {ex}");
                throw new InvalidOperationException("Delete is faill. Check your data and try again.", ex);
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
            bool exists = await _context.Courses
                .AnyAsync(c => c.Id == id, cancellationToken);

            if (!exists)
            {
                throw new KeyNotFoundException($"Курс с ID {id} не найден");
            }

            try
            {
                await _context.Courses
                      .Where(c => c.Id == id)
                      .ExecuteUpdateAsync(setter => setter.SetProperty(p => p.IsPublished, true), cancellationToken);
            }
            catch (DbException ex)
            {
                Trace.TraceError($"Error occurred: {ex}");
                throw new InvalidOperationException("Publish is faill. Check your data and try again.", ex);
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
            bool exists = await _context.Courses
                           .AnyAsync(c => c.Id == id, cancellationToken);

            if (!exists)
            {
                throw new KeyNotFoundException($"Курс с ID {id} не найден");
            }

            try
            {
                await _context.Courses
                      .Where(c => c.Id == id)
                      .ExecuteUpdateAsync(setter => setter.SetProperty(p => p.IsArchive, true), cancellationToken);
            }
            catch (DbException ex)
            {
                Trace.TraceError($"Error occurred: {ex}");
                throw new InvalidOperationException("Archive is faill. Check your data and try again.", ex);
            }
        }
    }
}
