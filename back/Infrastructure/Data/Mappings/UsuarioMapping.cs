using back.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back.Infrastructure.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIO");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Email);
            builder.Property(p => p.Senha);
            builder.Property(p => p.Active);
            builder.Property(p => p.Excluido);

        }
    }
}