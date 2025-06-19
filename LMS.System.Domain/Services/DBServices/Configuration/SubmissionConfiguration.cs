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
    /// Файл конфигурации Submission.
    /// </summary>
    public class SubmissionConfiguration : EntityConfiguration<Submission>
    {
        /// <summary>
        /// Метод конфигурации Submission.
        /// </summary>
        /// <param name="builder">Передаём builder.</param>
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<Submission> builder)
        {
            builder.ToTable("Submission"); // builder.HasCheckConstraint("CK_Gradle_Range", "[Gradle] >= 0 AND [Gradle] <= 10");

            builder.Property(p => p.AssignmentId)
                .HasColumnName("AssignmentId")
                .IsRequired();

            builder.Property(p => p.StudentId)
                .HasColumnName("StudentId")
                .IsRequired();

            builder.Property(p => p.AnswerText)
                .IsRequired()
                .HasColumnName("AnswerText")
                .HasMaxLength(4096);

            builder.Property(p => p.FilePath)
                .HasColumnName("FilePath");

            builder.Property(p => p.Gradle)
                .HasColumnName("Gradle")
                .IsRequired();

            builder.Property(p => p.Feedback)
                .HasColumnName("Feedback")
                .HasMaxLength(2048);

            builder.Property(p => p.SubmittedAt)
                .HasColumnName("SubmittedAt");
        }
    }
}
