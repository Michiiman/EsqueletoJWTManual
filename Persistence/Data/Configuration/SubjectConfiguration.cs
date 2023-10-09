using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Subject");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Name)
            .HasMaxLength(50);

            builder.HasOne(p => p.Teacher)
            .WithMany(p => p.Subjects)
            .HasForeignKey(p => p.TeacherIdFk);

            builder.HasOne(p => p.Student)
            .WithMany(p => p.Subjects)
            .HasForeignKey(p => p.StudentIdFk);
        }
    }
}