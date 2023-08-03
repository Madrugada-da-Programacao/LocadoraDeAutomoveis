﻿using FizzWare.NBuilder;
using LocadoraDeAutomoveis.Dominio;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Infra.Orm.Compartilhado;
using LocadoraDeAutomoveis.Infra.Orm.ModuloCliente;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeAutomoveis.TestesIntegracao.Compartilhado
{
    public class TestesIntegracaoBase
    {
        protected IRepositorioCliente RepositorioCliente { get; set; }

        public TestesIntegracaoBase()
        {
			InicializarOBanco();

			LimparTabelas();

			string connectionString = ObterConnectionString();

			var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeAutomoveisDbContext>();

			optionsBuilder.UseSqlServer(connectionString);

			var dbContext = new LocadoraDeAutomoveisDbContext(optionsBuilder.Options);

			var migracoesPendentes = dbContext.Database.GetPendingMigrations();

			if (migracoesPendentes.Count() > 0)
			{
				dbContext.Database.Migrate();
			}



			RepositorioCliente = new RepositorioClienteEmOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Cliente>(RepositorioCliente.Inserir);
        }

		protected static string? ObterConnectionString()
		{
			var configuracao = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var connectionString = configuracao.GetConnectionString("SqlServer");
			return connectionString;
		}

		protected static void InicializarOBanco()
		{
			var connectionString = ObterConnectionString();

			var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeAutomoveisDbContext>();

			optionsBuilder.UseSqlServer(connectionString);

			var dbContext = new LocadoraDeAutomoveisDbContext(optionsBuilder.Options);

			var migracoesPendentes = dbContext.Database.GetPendingMigrations();

			if (migracoesPendentes.Count() > 0)
			{
				dbContext.Database.Migrate();
			}
		}

		protected static void LimparTabelas()
        {
            string? connectionString = ObterConnectionString();

            SqlConnection sqlConnection = new SqlConnection(connectionString);

			string sqlLimpezaTabela =
				@"
                DELETE FROM [DBO].[TBCliente];";

			SqlCommand comando = new SqlCommand(sqlLimpezaTabela, sqlConnection);

            sqlConnection.Open();

            comando.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}