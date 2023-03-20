using NewSystem.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NewSystem.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(x => x.Imagem)
               .IsRequired()
               .HasColumnType("varchar(100)");

            //os demais campos que são decimal e datetime, não precisa ser mapeado porque são tipos unicos com tamanhos especificos

            builder.ToTable("Produtos");
        }
    }
}
