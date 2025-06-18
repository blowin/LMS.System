using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.System.Domain.Services.DBServices.Models.BaseClases;

namespace LMS.System.Domain.Services.DBServices.Models
{
    /// <summary>
    /// Submission: решения студентов по заданиям.
    /// </summary>
    public class Submission : Entity
    {
        /// <summary>
        /// Идентификатор задания, к которому относится эта сдача.
        /// </summary>
        public int AssignmentId { get; set; }

        /// <summary>
        /// Идентификатор студента, который сдал задание.
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Текстовый ответ студента на задание.
        /// </summary>
        public required string AnswerText { get; set; }

        /// <summary>
        /// Путь к файлу с решением, если задание было сдано в виде файла(необязательное поле).
        /// </summary>
        public string? FilePath { get; set; }

        /// <summary>
        /// Оценка ,выставленная за задание.
        /// </summary>
        [Range(0, 10)]
        public int Gradle { get; set; }

        /// <summary>
        /// Обратная связь от проверяющего, содержащая комментарии и рекомендации(необязательное поле).
        /// </summary>
        public string? Feedback { get; set; }

        /// <summary>
        /// Дата отправки решения задания.
        /// </summary>
        public DateTime SubmittedAt { get; set; }

        /// <summary>
        /// навигационное свойство для Assignment.
        /// </summary>
        public Assignment? SubmissionForAssignment { get; set; }

        /// <summary>
        /// навигационное свойство для юзера.
        /// </summary>
        public User? UserForSub { get; set; }
    }
}
