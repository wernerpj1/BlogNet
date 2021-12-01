using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using back.Business.Entities;

namespace back.Infrastructure.Data.Mappings
{
    public class ArtigoMapping : IEntityTypeConfiguration<Artigo>
    {
        public void Configure(EntityTypeBuilder<Artigo> builder)
        {
            builder.ToTable("TB_ARTIGO");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Titulo);
            builder.Property(p => p.Texto);
            builder.HasOne(p => p.Usuario)
                    .WithMany().HasForeignKey(fk => fk.UsuarioId);
            builder.HasOne(p => p.SubCategoria)
                    .WithMany().HasForeignKey(fk => fk.SubcategoriaId);
            builder.HasOne(p => p.Imagens)
                    .WithMany().HasForeignKey(fk => fk.ImagemId);
        }
    }
}