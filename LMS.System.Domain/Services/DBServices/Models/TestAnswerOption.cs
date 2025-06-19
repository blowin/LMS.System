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
    /// Вариант ответа на тестовое задание.
    /// </summary>
    public class TestAnswerOption : Entity
    {
        /// <summary>
        /// Поле связывающее вопрос и ответы.
        /// </summary>
        public int TestQuestionId { get; set; }

        /// <summary>
        /// Описание варианта ответа.
        /// </summary>
        public required string OptionText { get; set; }

        /// <summary>
        /// Получает или задаёт значение, указывающее, является ли этот вариант ответа корректным.
        /// </summary>
        public bool IsCorrect { get; set; }

        /// <summary>
        /// Навигационное свойство для TestQuestion.
        /// </summary>
        public TestQuestion? TestQuestion { get; set; }
    }
}
