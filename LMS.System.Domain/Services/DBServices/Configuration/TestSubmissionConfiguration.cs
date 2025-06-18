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
    /// Файл конфигурации TestSubmission.
    /// </summary>
    public class TestSubmissionConfiguration : IEntityTypeConfiguration<TestSubmission>
    {
        /// <summary>
        /// Метод конфигурации TestSubmission.
        /// </summary>
        /// <param name="builder">Передаём builder.</param>
        public void Configure(EntityTypeBuilder<TestSubmission> builder)
        {
            builder.ToTable("TestSubmission");

            builder.HasKey(k => k.Id);

            builder.HasMany(e => e.TestAnswerOptions)
                .WithOne(e => e.TestSubmission)
                .HasForeignKey(k => k.TestQuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.TestQuestionId)
                .HasColumnName("TestQuestionId")
                .IsRequired();

            builder.Property(p => p.SubmissionId)
                .HasColumnName("SubmissionId")
                .IsRequired();

            builder.Property(p => p.SelectedOptionId)
                .HasColumnName("SelectedOptionId");
        }
    }
}
