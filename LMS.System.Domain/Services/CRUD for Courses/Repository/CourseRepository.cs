using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.System.Domain.Services.CRUD_for_Courses.Interfaces;
using LMS.System.Domain.Services.DBServices.DBContext;
using LMS.System.Domain.Services.DBServices.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.System.Domain.Services.CRUD_for_Courses.Repository
{
    /// <summary>
    /// Реализация ICourseRepository.
    /// </summary>
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// Constructor which get a context.
        /// </summary>
        /// <param name="context">Send a context.</param>
        public CourseRepository(ApplicationContext context)
        {
            _context = context;
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
    }
}
