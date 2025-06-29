using LMS.System.Domain.Services.DBServices.Configuration.PropertyBuilderExt;
using LMS.System.Domain.Services.DBServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.System.Domain.Services.DBServices.Configuration
{
    /// <summary>
    /// Файл конфигурации TestQuestion.
    /// </summary>
    public class TestQuestionConfiguration : EntityConfiguration<TestQuestion>
    {
        /// <summary>
        /// Метод конфигурации TestQuestion.
        /// </summary>
        /// <param name="builder">Передаем builder.</param>
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<TestQuestion> builder)
        {
            builder.ToTable("TestQuestion");

            builder.HasMany(p => p.TestSubmissions)
                .WithOne(p => p.TestQuestion)
                .HasForeignKey(p => p.TestQuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.AssignmentId)
                .HasColumnName("AssignmentId")
                .IsRequired();

            builder.Property(p => p.QuestionText)
                .IsRequired()
                .HasColumnName("QuestionText")
                .HasMaxLength(512);

            builder.Property(p => p.QuestionType)
                .HasColumnName("QuestionType")
                .HasEnumComment()
                .IsRequired();
        }
    }
}
