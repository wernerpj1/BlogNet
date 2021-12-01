using back.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back.Infrastructure.Data.Mappings
{
    public class ImagensMapping : IEntityTypeConfiguration<Imagens>
    {
        public void Configure(EntityTypeBuilder<Imagens> builder)
        {
            builder.ToTable("TB_IMAGEM");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.SlugImagem);
        }
    }
}
