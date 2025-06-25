using LMS.System.Domain.Services.DBServices.Configuration.PropertyBuilderExt;
using LMS.System.Domain.Services.DBServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.System.Domain.Services.DBServices.Configuration
{
    /// <summary>
    /// Файл конфигурации Lesson.
    /// </summary>
    public class LessonConfiguration : EntityConfiguration<Lesson>
    {
        /// <summary>
        /// Метод конфигурации Lesson.
        /// </summary>
        /// <param name="builder">передаем builder.</param>
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lesson");

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Title");

            builder.Property(p => p.FilePDFPath)
                .HasColumnName("FilePDFPath")
                .HasMaxLength(512);

            builder.Property(p => p.MoviesPath)
                .HasColumnName("MoviesPath")
                .HasMaxLength(512);

            builder.Property(p => p.Content)
                .IsRequired()
                .HasColumnName("Content")
                .HasMaxLength(4096);

            builder.Property(p => p.CourseId)
                .HasColumnName("CourseId")
                .IsRequired();

            builder.Property(p => p.Order)
                .HasColumnName("Order")
                .IsRequired();

            builder.Property(p => p.LessonType)
                .HasColumnName("LessonType")
                .HasEnumComment()
                .IsRequired();
        }
    }
}
