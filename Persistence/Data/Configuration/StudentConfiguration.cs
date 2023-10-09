using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Student");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(p => p.Class)
            .WithMany(p => p.Students)
            .HasForeignKey(p => p.ClassIdFk);
        }
    }
}