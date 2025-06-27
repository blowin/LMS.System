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
    /// валидатор для CourseCreateRequest.
    /// </summary>
    public class CourseCreateRequestValidator : AbstractValidator<CourseCreateRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseCreateRequestValidator"/> class with validation for CourseUpdateRequest.
        /// </summary>
        /// <param name="value">Send a context.</param>
        public CourseCreateRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Название курса обязательно")
                .MaximumLength(256).WithMessage("Название слишком длинное");

            RuleFor(x => x.Description)
                .MaximumLength(2048).WithMessage("Описание слишком длинное");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Неверная категория");

            RuleFor(x => x.InstructorId)
                .GreaterThan(0).WithMessage("Неверный инструктор");
        }
    }
}
