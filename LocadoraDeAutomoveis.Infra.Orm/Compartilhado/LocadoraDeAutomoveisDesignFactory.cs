using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeAutomoveis.Infra.Orm.Compartilhado
{
    internal class LocadoraDeAutomoveisDesignFactory : IDesignTimeDbContextFactory<LocadoraDeAutomoveisDbContext>
    {
        public LocadoraDeAutomoveisDbContext CreateDbContext(string[] args)
        {            
            var configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeAutomoveisDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new LocadoraDeAutomoveisDbContext(optionsBuilder.Options);
        }
    }
}
