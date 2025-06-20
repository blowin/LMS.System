using LMS.System.Domain.Services.DBServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.System.Domain.Services.DBServices.Configuration
{
    /// <summary>
    /// Файл конфигурации для Enrollment.
    /// </summary>
    public class EnrollmentConfiguration : EntityConfiguration<Enrollment>
    {
        /// <summary>
        /// Метод конфигурации Enrollment.
        /// </summary>
        /// <param name="builder">Передаём builder.</param>
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment");

            builder.Property(p => p.StudentId)
                .HasColumnName("StudentId")
                .IsRequired();

            builder.Property(p => p.CourseId)
                .HasColumnName("CourseId")
                .IsRequired();

            builder.Property(p => p.EnrollmentDate)
                .HasColumnName("EnrollmentDate")
                .IsRequired();

            builder.Property(p => p.Completed)
                .HasColumnName("Completed")
                .HasDefaultValue(false);

            builder.HasOne(e => e.UsersForEnrollment)
                   .WithMany(u => u.EnrollmentForUsers)
                   .HasForeignKey(e => e.StudentId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.CoursesForEnrollment)
                   .WithMany(c => c.EnrollmentInCourse)
                   .HasForeignKey(e => e.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
