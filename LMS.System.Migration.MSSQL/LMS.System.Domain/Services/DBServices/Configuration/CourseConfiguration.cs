using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.System.Domain.Services.DBServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.System.Domain.Services.DBServices.Configuration
{
    /// <summary>
    /// Файл конфигурации для Course.
    /// </summary>
    public class CourseConfiguration : EntityConfiguration<Course>
    {
        /// <summary>
        /// Перегрузка метода конфигурации.
        /// </summary>
        /// <param name="builder">Передаём builder.</param>
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnName("Title");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasMaxLength(2048);

            builder.Property(p => p.CategoryId)
                .HasColumnName("CategoryId")
                .IsRequired();

            builder.Property(p => p.InstructorId)
                .HasColumnName("InstructorId")
                .IsRequired();

            builder.Property(p => p.IsPublished)
                .IsRequired()
                .HasColumnName("IsPubliched")
                .HasDefaultValue(true);

            builder.HasMany(p => p.EnrollmentInCourse)
                .WithOne(p => p.CoursesForEnrollment)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.LessonsInCourse)
                .WithOne(p => p.CourseForLesson)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.AssignmentsInCourse)
                .WithOne(p => p.CourseForAssignment)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
