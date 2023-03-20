using NewSystem.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NewSystem.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            //1 : 1 => Fornecedor : Endereco
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Fornecedor);

            //1 : n => Fornecedor : Produtos
            builder.HasMany(f => f.Produtos) //Tabela Fornecedor
                .WithOne(p => p.Fornecedor) //Tabela Produto
                .HasForeignKey(p => p.FornecedorId); //Tabela Produto

            builder.ToTable("Fornecedores");
        }
    }
}
