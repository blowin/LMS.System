using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LMS.System.Domain.Services.CourseManagement.CourseRequest;

namespace LMS.System.Domain.Services.CourseManagement.Validator
{
    /// <summary>
    /// Валидацию для CourseUpdateRequest.
    /// </summary>
    public class CourseUpdateRequestValidator : AbstractValidator<CourseUpdateRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseUpdateRequestValidator"/> class with validation for CourseUpdateRequest.
        /// </summary>
        /// <param name="value">Send a context.</param>
        public CourseUpdateRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("ID курса должен быть положительным числом.");

            RuleFor(x => x.Title)
                .MaximumLength(256)
                .WithMessage("Название курса не должно превышать 100 символов.")
                .When(x => x.Title != null);

            RuleFor(x => x.Description)
                .MaximumLength(2048)
                .WithMessage("Описание курса не должно превышать 2000 символов.")
                .When(x => x.Description != null);

            RuleFor(x => x.IsPublished)
                .NotNull()
                .When(x => x.IsPublished.HasValue)
                .WithMessage("Статус публикации должен быть true или false.");
        }
    }
}
