using FiapStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.NomeUsuario)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();
            builder.Property(x => x.Senha)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();
            builder.Property(x => x.Permissao)
                .HasConversion<int>()
                .IsRequired();
            builder.HasMany(x => x.Pedidos)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
