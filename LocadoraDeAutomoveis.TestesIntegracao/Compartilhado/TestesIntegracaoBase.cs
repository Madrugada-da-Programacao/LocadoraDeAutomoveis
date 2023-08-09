using FizzWare.NBuilder;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.Infra.Dados.Arquivo.Compartilhado;
using LocadoraDeAutomoveis.Infra.Dados.Arquivo.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraDeAutomoveis.Infra.Orm.ModuloFuncionario;
using LocadoraDeAutomoveis.Infra.Orm.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.Infra.Orm.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.Infra.Orm.ModuloGrupoDeAutomoveis;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocadoraDeAutomoveis.Dominio.ModuloParceiro;
using LocadoraDeAutomoveis.Infra.Orm.ModuloParceiro;
using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Infra.Orm.ModuloCondutor;

namespace LocadoraDeAutomoveis.TestesIntegracao.Compartilhado
{
    public class TestesIntegracaoBase
    {
		//protected IRepositorioCliente RepositorioCliente { get; set; }------------> Aluguel
		//protected IRepositorioCliente RepositorioCliente { get; set; }------------> Automovel
		protected IRepositorioCliente RepositorioCliente { get; set; }
		protected IRepositorioCondutor RepositorioCondutor { get; set; }
		//protected IRepositorioCliente RepositorioCliente { get; set; }------------> Cupom
		protected IRepositorioFuncionario RepositorioFuncionario { get; set; }
		protected IRepositorioGrupoDeAutomoveis RepositorioGrupoDeAutomoveis { get; set; }
		protected IRepositorioParceiro RepositorioParceiro { get; set; }
        protected IRepositorioPlanoDeCobranca RepositorioPlanoDeCobranca { get; set; }
		protected IRepositorioTaxaOuServico RepositorioTaxaOuServico { get; set; }
		protected IRepositorioConfiguracaoDePrecos RepositorioConfiguracaoDePrecos { get; set; }
		protected IContextoPersistencia ContextoPersistencia { get; set; }
		protected ContextoDados ContextoDadosArquivo { get; set; }


        public TestesIntegracaoBase()
        {
			LimparTabelas();

            ContextoDadosArquivo = new ContextoDados("Compartilhado\\LocadoraDeAutomoveisTest.json");

			LimparArquivo();

			string? connectionString = ObterConnectionString();

			var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeAutomoveisDbContext>();

			optionsBuilder.UseSqlServer(connectionString);

			var dbContext = new LocadoraDeAutomoveisDbContext(optionsBuilder.Options);
			ContextoPersistencia = dbContext;

			//RepositorioCliente = new RepositorioClienteEmOrm(dbContext);------------> Aluguel
			//RepositorioCliente = new RepositorioClienteEmOrm(dbContext);------------> Automovel
			RepositorioCliente = new RepositorioClienteEmOrm(dbContext);
			RepositorioCondutor = new RepositorioCondutorEmOrm(dbContext);
			//RepositorioCliente = new RepositorioClienteEmOrm(dbContext);------------> Cupom
            RepositorioFuncionario = new RepositorioFuncionarioEmOrm(dbContext);
            RepositorioGrupoDeAutomoveis = new RepositorioGrupoDeAutomoveisOrm(dbContext);
			RepositorioParceiro = new RepositorioParceiroEmOrm(dbContext);
			RepositorioPlanoDeCobranca = new RepositorioPlanoDeCobrancaEmOrm(dbContext);
			RepositorioTaxaOuServico = new RepositorioTaxaOuServicoEmOrm(dbContext);
			RepositorioConfiguracaoDePrecos = new RepositorioConfiguracaoDePrecosEmArquivo(ContextoDadosArquivo);

			//TODO
			//BuilderSetup.SetCreatePersistenceMethod<Cliente>(cliente =>------------> Aluguel
			//{
			//	RepositorioCliente.Inserir(cliente);
			//	ContextoPersistencia.GravarDados();
			//});

			//TODO
			//BuilderSetup.SetCreatePersistenceMethod<Cliente>(cliente =>------------> Automovel
			//{
			//	RepositorioCliente.Inserir(cliente);
			//	ContextoPersistencia.GravarDados();
			//});


			BuilderSetup.SetCreatePersistenceMethod<Cliente>(cliente =>
			{
				RepositorioCliente.Inserir(cliente);
				ContextoPersistencia.GravarDados();
			});

			BuilderSetup.SetCreatePersistenceMethod<Condutor>(condutor =>
			{
				RepositorioCondutor.Inserir(condutor);
				ContextoPersistencia.GravarDados();
			});

			//TODO
			//BuilderSetup.SetCreatePersistenceMethod<Cliente>(cliente =>------------> Cupom
			//{
			//	RepositorioCliente.Inserir(cliente);
			//	ContextoPersistencia.GravarDados();
			//});

			BuilderSetup.SetCreatePersistenceMethod<Funcionario>(funcionario =>
			{
				RepositorioFuncionario.Inserir(funcionario);
				ContextoPersistencia.GravarDados();
			});

			BuilderSetup.SetCreatePersistenceMethod<GrupoDeAutomoveis>(grupoDeAutomoveis =>
			{
				RepositorioGrupoDeAutomoveis.Inserir(grupoDeAutomoveis);
				ContextoPersistencia.GravarDados();
			});

			BuilderSetup.SetCreatePersistenceMethod<Parceiro>(parceiro =>
			{
				RepositorioParceiro.Inserir(parceiro);
				ContextoPersistencia.GravarDados();
			});

			BuilderSetup.SetCreatePersistenceMethod<PlanoDeCobranca>(planoDeCobranca =>
			{
				RepositorioPlanoDeCobranca.Inserir(planoDeCobranca);
				ContextoPersistencia.GravarDados();
			});

			BuilderSetup.SetCreatePersistenceMethod<TaxaOuServico>(taxaOuServico =>
			{
				RepositorioTaxaOuServico.Inserir(taxaOuServico);
				ContextoPersistencia.GravarDados();
			});
		}

        private void LimparArquivo()
        {
			ContextoDadosArquivo.ConfiguracaoDePrecos = new ConfiguracaoDePrecos(1,1,1,1);

			ContextoDadosArquivo.GravarEmArquivoJson();
        }

        protected static void LimparTabelas()
		{
			string? connectionString = ObterConnectionString();

			SqlConnection sqlConnection = new SqlConnection(connectionString);

			string sqlLimpezaTabela =
				@"" //TODO Aluguel
			   + "" //TODO Automovel
			   + "DELETE FROM [DBO].[TBCONDUTOR];"
               + "DELETE FROM [DBO].[TBCLIENTE];" 
               + "" //TODO Cupom
			   + "DELETE FROM [DBO].[TBFUNCIONARIO];"
			   + "DELETE FROM [DBO].[TBPLANODECOBRANCA];"
			   + "DELETE FROM [DBO].[TBGRUPODEAUTOMOVEIS];"
			   + "DELETE FROM [DBO].[TBPARCEIRO];"
			   + "DELETE FROM [DBO].[TBTAXAOUSERVICO];";
				

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