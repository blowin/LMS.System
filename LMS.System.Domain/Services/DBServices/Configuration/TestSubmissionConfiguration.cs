using LMS.System.Domain.Services.DBServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.System.Domain.Services.DBServices.Configuration
{
    /// <summary>
    /// Файл конфигурации TestSubmission.
    /// </summary>
    public class TestSubmissionConfiguration : EntityConfiguration<TestSubmission>
    {
        /// <summary>
        /// Метод конфигурации TestSubmission.
        /// </summary>
        /// <param name="builder">Передаём builder.</param>
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<TestSubmission> builder)
        {
            builder.ToTable("TestSubmission");

            builder.Property(p => p.TestQuestionId)
                .HasColumnName("TestQuestionId")
                .IsRequired();

            builder.Property(p => p.SubmissionId)
                .HasColumnName("SubmissionId")
                .IsRequired();

            builder.Property(p => p.SelectedOptionId)
                .HasColumnName("SelectedOptionId")
                .IsRequired();
        }
    }
}
