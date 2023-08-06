using FizzWare.NBuilder;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.Infra.Dados.Arquivo.Compartilhado;
using LocadoraDeAutomoveis.Infra.Dados.Arquivo.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Infra.Orm.Compartilhado;
using LocadoraDeAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraDeAutomoveis.Infra.Orm.ModuloFuncionario;
using LocadoraDeAutomoveis.Infra.Orm.ModuloTaxaOuServico;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeAutomoveis.TestesIntegracao.Compartilhado
{
    public class TestesIntegracaoBase
    {
        protected IRepositorioCliente RepositorioCliente { get; set; }
		protected IRepositorioTaxaOuServico RepositorioTaxaOuServico { get; set; }
        protected IRepositorioFuncionario RepositorioFuncionario { get; set; }
		protected IRepositorioConfiguracaoDePrecos RepositorioConfiguracaoDePrecos { get; set; }
		protected ContextoDados Contexto { get; set; }


        public TestesIntegracaoBase()
        {
			LimparTabelas();

			LimparArquivo();

			string? connectionString = ObterConnectionString();

			var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeAutomoveisDbContext>();

			optionsBuilder.UseSqlServer(connectionString);

			var dbContext = new LocadoraDeAutomoveisDbContext(optionsBuilder.Options);

            Contexto = new ContextoDados("Compartilhado\\LocadoraDeAutomoveisTest.json");

			RepositorioCliente = new RepositorioClienteEmOrm(dbContext);
			RepositorioTaxaOuServico = new RepositorioTaxaOuServicoEmOrm(dbContext);
            RepositorioFuncionario = new RepositorioFuncionarioEmOrm(dbContext);
			RepositorioConfiguracaoDePrecos = new RepositorioConfiguracaoDePrecosEmArquivo(Contexto);

            BuilderSetup.SetCreatePersistenceMethod<TaxaOuServico>(RepositorioTaxaOuServico.Inserir);

            BuilderSetup.SetCreatePersistenceMethod<Cliente>(RepositorioCliente.Inserir);

            BuilderSetup.SetCreatePersistenceMethod<Funcionario>(RepositorioFuncionario.Inserir);
        }

        private void LimparArquivo()
        {
			Contexto.ConfiguracaoDePrecos = new ConfiguracaoDePrecos(1,1,1,1);

			Contexto.GravarEmArquivoJson();
        }

        protected static void LimparTabelas()
		{
			string? connectionString = ObterConnectionString();

			SqlConnection sqlConnection = new SqlConnection(connectionString);

			string sqlLimpezaTabela =
				@"
                DELETE FROM [DBO].[TBCliente];
                DELETE FROM [DBO].[TBFUNCIONARIO];
				DELETE FROM [DBO].[TBTaxaOuServico];";

            SqlCommand comando = new SqlCommand(sqlLimpezaTabela, sqlConnection);

			sqlConnection.Open();

			comando.ExecuteNonQuery();

			sqlConnection.Close();
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
	}
}