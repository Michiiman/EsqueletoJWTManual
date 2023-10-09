using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("class");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Name)
            .HasColumnName("ClassName")
            .IsRequired();
        }
    }
}