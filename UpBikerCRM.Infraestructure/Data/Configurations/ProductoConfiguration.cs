using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static UpBikerCRM.Core.Entities.Inventario;

namespace UpBikerCRM.Infraestructure.Data.Configurations
{
    internal class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");

            builder.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        }
    }
}
