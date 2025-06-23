using LMS.System.Domain.Services.DBServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.System.Domain.Services.DBServices.Configuration
{
    /// <summary>
    /// Файл конфигурации Category.
    /// </summary>
    public class CategoryConfiguration : EntityConfiguration<Category>
    {
        /// <summary>
        /// Метод для конфигурации.
        /// </summary>
        /// <param name="builder">.</param>
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnName("Name");

            builder.HasMany(p => p.Courses)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
