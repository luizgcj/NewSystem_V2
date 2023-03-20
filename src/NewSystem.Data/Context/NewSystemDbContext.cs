using NewSystem.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NewSystem.Data.Context
{
    public class NewSystemDbContext : DbContext
    {
        public NewSystemDbContext(DbContextOptions options) : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //caso tenha esquecido de mapear algum campo string, para evitar que o entity framework crie o campo com o nvarchar(max)
            //basta usar o código abaixo e ele irá utilizar o varchar(100) sem sobrescrever o que já possui os tipos configurados
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NewSystemDbContext).Assembly);

            //Esta configuração serve para não excluir os registros filhos em cascata, nesse caso é necessário excluir pela aplicação
            foreach(var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) 
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;   

            base.OnModelCreating(modelBuilder);
        }
    }
}
