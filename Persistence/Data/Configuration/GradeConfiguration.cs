using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Grade");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
        
            builder.Property(p => p.Score)
            .HasColumnType("Double")
            .HasMaxLength(5);

            builder.HasOne(p => p.Subject)
            .WithMany(p => p.Grades)
            .HasForeignKey(p => p.SubjectIdFk);
        }
    }
}