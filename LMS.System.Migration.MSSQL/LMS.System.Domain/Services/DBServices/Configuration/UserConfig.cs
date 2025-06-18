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
    /// kzkzkz.
    /// </summary>
    public class UserConfig : EntityConfiguration<User>
    {
        /// <summary>
        /// Конфигурация для User.
        /// </summary>
        /// <param name="builder">Передаём builder.</param>
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .IsRequired().HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.PasswordHash)
                .HasColumnName("PasswordHash")
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.FirstName)
                .HasColumnName("FirstName")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .HasColumnName("LastName")
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(p => p.CoursesForUser)
                .WithOne(p => p.Users)
                .HasForeignKey(p => p.InstructorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.EnrollmentForUsers)
                .WithOne(p => p.UsersForEnrollment)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(p => p.SubmissionsForUser)
                .WithOne(p => p.UserForSub)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Role)
                .HasColumnName("UsersRole");
        }
    }
}
