using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.System.Domain.Services.DBServices.Models.BaseClases;

namespace LMS.System.Domain.Services.DBServices.Models
{
    /// <summary>
    /// Enrollment: информация о том, какие студенты записаны на курс.
    /// </summary>
    public class Enrollment : Entity
    {
        /// <summary>
        /// Уникальный номер студента.
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Уникальный номер курса.
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Дата зачисления.
        /// </summary>
        public DateTime EnrollmentDate { get; set; }

        /// <summary>
        /// Флаг завершения операции зачисления.
        /// </summary>
        public bool Completed { get; set; }

        /// <summary>
        /// навигационное свойство для юзера.
        /// </summary>
        public User? UsersForEnrollment { get; set; }

        /// <summary>
        /// навигационное свойство для курсов.
        /// </summary>
        public Course? CoursesForEnrollment { get; set; }
    }
}
