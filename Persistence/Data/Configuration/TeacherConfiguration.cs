using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Teacher");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Name)
            .HasMaxLength(50);

            builder.Property(p => p.Lastname)
            .HasMaxLength(50);
        }
    }
}