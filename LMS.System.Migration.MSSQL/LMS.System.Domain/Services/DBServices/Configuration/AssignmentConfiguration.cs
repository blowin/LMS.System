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
    /// Параметры для Assignment.
    /// </summary>
    public class AssignmentConfiguration : EntityConfiguration<Assignment>
    {
        /// <summary>
        /// Перегрузка метода конфигурации.
        /// </summary>
        /// <param name="builder">Передаём builder.</param>
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignment");

            builder.Property(p => p.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasMaxLength(255);

            builder.Property(p => p.Deadline)
                .HasColumnName("Deadline");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasMaxLength(2048);

            builder.Property(p => p.CourseId)
                .HasColumnName("CourseId")
                .IsRequired();

            builder.Property(p => p.AssignmentType)
                .HasColumnName("AssignmentType");

            builder.HasMany(p => p.TestQuestionsInAssignment)
                .WithOne(p => p.Assignment)
                .HasForeignKey(p => p.AssignmentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.SubmissionsInAssignment)
                .WithOne(p => p.SubmissionForAssignment)
                .HasForeignKey(p => p.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.CourseForAssignment)
                .WithMany(p => p.AssignmentsInCourse)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
