using FiapStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(p => p.NomeProduto)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
            builder.Property(p => p.PrecoTotal)
                .HasColumnType("DECIMAL(10,2)")
                .IsRequired();
            builder.HasOne(p => p.Usuario)
                .WithMany(u => u.Pedidos)
                .HasPrincipalKey(p => p.Id);
        }
    }
}
