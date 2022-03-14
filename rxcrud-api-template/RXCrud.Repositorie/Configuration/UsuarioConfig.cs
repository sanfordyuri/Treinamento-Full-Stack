using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RXCrud.Domain.Entities;

namespace RXCrud.Data.Configuration
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Nome).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Senha).IsRequired();
            builder.HasIndex(u => u.NomeAcesso).IsUnique();
            builder.Property(u => u.NomeAcesso).IsRequired();
        }
    }
}