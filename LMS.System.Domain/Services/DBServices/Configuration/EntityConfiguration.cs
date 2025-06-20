using LMS.System.Domain.Services.DBServices.Models.BaseClases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.System.Domain.Services.DBServices.Configuration
{
    /// <summary>
    /// Базовая конфигурация.
    /// </summary>
    /// <typeparam name="T">Шаблон для моделей наследников.</typeparam>
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        /// <summary>
        /// метод базовой конфигурации.
        /// </summary>
        /// <param name="builder">builder базовой конфигурации.</param>
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("CreatedAt");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("UpdatedAt");

            ConfigureAdditionalProperties(builder);
        }

        /// <summary>
        /// Метод созданный для перегрузки наследниками.
        /// </summary>
        /// <param name="builder">builder.</param>
        protected abstract void ConfigureAdditionalProperties(EntityTypeBuilder<T> builder);
    }
}
