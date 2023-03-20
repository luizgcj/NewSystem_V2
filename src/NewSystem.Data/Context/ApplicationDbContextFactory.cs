using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NewSystem.Data.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<NewSystemDbContext>
    {
        public NewSystemDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=LUIZPC\\SQLEXPRESS;Database=NewSystemDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var optionsBuilder = new DbContextOptionsBuilder<NewSystemDbContext>();
            optionsBuilder.UseSqlServer(connectionString);           

            return new NewSystemDbContext(optionsBuilder.Options);
        }
    }
}
