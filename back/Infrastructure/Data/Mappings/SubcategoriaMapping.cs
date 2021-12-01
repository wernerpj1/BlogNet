

using back.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back.Infrastructure.Data.Mappings
{
    public class SubcategoriaMapping : IEntityTypeConfiguration<SubCategoria>
    {
        public void Configure(EntityTypeBuilder<SubCategoria> builder)
        {
            builder.ToTable("TB_SUBCATEGORIA");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome);
            builder.Property(p => p.SlugSubCategoria);
            builder.HasOne(p => p.Categoria)
                    .WithMany().HasForeignKey(fk => fk.IdCategoria);

        }
    }
}