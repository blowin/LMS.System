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
    /// Отправка теста.
    /// </summary>
    public class TestSubmission : Entity
    {
        /// <summary>
        /// Поле связывающее вопрос и ответ на него.
        /// </summary>
        public int TestQuestionId { get; set; }

        /// <summary>
        /// Поле связывающее решение и ответ на тест.
        /// </summary>
        public int SubmissionId { get; set; }

        /// <summary>
        /// Идентификатор выбранного варианта ответа.
        /// </summary>
        public int SelectedOptionId { get; set; }

        /// <summary>
        /// Навигационное свойство для TestQuestion.
        /// </summary>
        public TestQuestion? TestQuestion { get; set; }

        /// <summary>
        /// Навигационное свуойство для Submission.
        /// </summary>
        public Submission? Submission { get; set; }
    }
}
