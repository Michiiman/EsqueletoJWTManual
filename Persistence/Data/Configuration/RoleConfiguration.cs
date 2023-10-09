using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Role");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasMaxLength(3);
        
            builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasMaxLength(50);
        }
    }
}