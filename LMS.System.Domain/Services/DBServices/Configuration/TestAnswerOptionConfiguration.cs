using LMS.System.Domain.Services.DBServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.System.Domain.Services.DBServices.Configuration
{
    /// <summary>
    /// Файл конфигурации TestAnswerOption.
    /// </summary>
    public class TestAnswerOptionConfiguration : EntityConfiguration<TestAnswerOption>
    {
        /// <summary>
        /// метод конфигурации TestAnswerOption.
        /// </summary>
        /// <param name="builder">Передаём builder.</param>
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<TestAnswerOption> builder)
        {
            builder.ToTable("TestAnswerOption");

            builder.Property(p => p.TestQuestionId)
                .HasColumnName("TestQuestionId")
                .IsRequired();

            builder.Property(p => p.OptionText)
                .IsRequired()
                .HasColumnName("OptionText")
                .HasMaxLength(512);

            builder.Property(p => p.IsCorrect)
                .IsRequired()
                .HasColumnName("IsCorrect")
                .HasDefaultValue(false);
        }
    }
}
