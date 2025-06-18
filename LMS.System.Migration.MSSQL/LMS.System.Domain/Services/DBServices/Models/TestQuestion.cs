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
    /// Вопросы в виде теста.
    /// </summary>
    public class TestQuestion : Entity
    {
        /// <summary>
        /// Поле связывающее задание и вопрос.
        /// </summary>
        public int AssignmentId { get; set; }

        /// <summary>
        /// Текст самого вопроса.
        /// </summary>
        public required string QuestionText { get; set; }

        /// <summary>
        /// Тип вопроса один/несколько вариант(ов) ответа.
        /// </summary>
        public EVTypeQuestion QuestionType { get; set; }

        /// <summary>
        /// Навигационное свойство для Assignment.
        /// </summary>
        public Assignment? Assignment { get; set; }

        /// <summary>
        /// Коллекция вариантов ответа.
        /// </summary>
        public ICollection<TestAnswerOption> TestAnswerOptions { get; set; } = new List<TestAnswerOption>();
    }

    /// <summary>
    /// Перечисление типов вопроса.
    /// </summary>
    public enum EVTypeQuestion
    {
        /// <summary>
        /// Один вариант ответа верный.
        /// </summary>
        SingleChoice,

        /// <summary>
        /// Несколько вариантов ответа верны.
        /// </summary>
        MultiChoice,
    }
}
