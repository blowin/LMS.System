using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.System.Domain.Services.DBServices.Models.BaseClases;
using Microsoft.VisualBasic;

namespace LMS.System.Domain.Services.DBServices.Models
{
    /// <summary>
    /// User: содержит информацию о пользователях (студенты, преподаватели, админы).
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public required string PasswordHash { get; set; }

        /// <summary>
        /// Роль пользователя(Админ,Преподаватель,Студент).
        /// </summary>
        public EVUsersRole Role { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Отчество пользователя.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Коллекция курсов юзера.
        /// </summary>
        public ICollection<Course> CoursesForUser { get; set; } = new List<Course>();

        /// <summary>
        /// коллекция зачисленных студентов.
        /// </summary>
        public ICollection<Enrollment> EnrollmentForUsers { get; set; } = new List<Enrollment>();

        /// <summary>
        /// коллекция отправленных решений пользователя.
        /// </summary>
        public ICollection<Submission> SubmissionsForUser { get; set; } = new List<Submission>();
    }

    /// <summary>
    /// Роли для пользователя.
    /// </summary>
    public enum EVUsersRole
    {
        /// <summary>
        /// Роль админ.
        /// </summary>
        Admin,

        /// <summary>
        /// Роль преподаватель.
        /// </summary>
        Teacher,

        /// <summary>
        /// Роль студент.
        /// </summary>
        Student,
    }
}
