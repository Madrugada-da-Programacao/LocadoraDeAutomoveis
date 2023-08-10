using LocadoraDeAutomoveis.Aplicacao.ModuloAutomovel;
using LocadoraDeAutomoveis.Aplicacao.ModuloCliente;
using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Aplicacao.ModuloCupom;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Aplicacao.ModuloParceiro;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.Dominio;
using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Dominio.ModuloCupom;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloParceiro;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.Infra.Dados.Arquivo.Compartilhado;
using LocadoraDeAutomoveis.Infra.Dados.Arquivo.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Infra.Orm.Compartilhado;
using LocadoraDeAutomoveis.Infra.Orm.ModuloAutomovel;
using LocadoraDeAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraDeAutomoveis.Infra.Orm.ModuloCupom;
using LocadoraDeAutomoveis.Infra.Orm.ModuloFuncionario;
using LocadoraDeAutomoveis.Infra.Orm.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Infra.Orm.ModuloParceiro;
using LocadoraDeAutomoveis.Infra.Orm.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.Infra.Orm.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.WinApp.ModuloAutomovel;
using LocadoraDeAutomoveis.WinApp.ModuloCliente;
using LocadoraDeAutomoveis.WinApp.ModuloCupom;
using LocadoraDeAutomoveis.WinApp.ModuloFuncionario;
using LocadoraDeAutomoveis.WinApp.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.WinApp.ModuloParceiro;
using LocadoraDeAutomoveis.WinApp.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.WinApp.ModuloTaxaOuServico;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraDeAutomoveis.WinApp.Compartilhado.IoC
{
	public class IoC_ComInjecaoDependencia : IoC
	{
		private ServiceProvider container;

		public IoC_ComInjecaoDependencia()
		{
			var configuracao = new ConfigurationBuilder()
			   .SetBasePath(Directory.GetCurrentDirectory())
			   .AddJsonFile("appsettings.json")
			   .Build();

			var connectionString = configuracao.GetConnectionString("SqlServer");

			var servicos = new ServiceCollection();

			servicos.AddDbContext<IContextoPersistencia, LocadoraDeAutomoveisDbContext>(optionsBuilder =>
			{
				optionsBuilder.UseSqlServer(connectionString);
			});

			////TODO
			//servicos.AddTransient<ControladorCliente>();--------------------> Aluguel
			//servicos.AddTransient<ServicoCliente>();
			//servicos.AddTransient<IValidadorCliente, ValidadorCliente>();
			//servicos.AddTransient<IRepositorioCliente, RepositorioClienteEmOrm>();

			servicos.AddTransient<ControladorAutomovel>();
			servicos.AddTransient<ServicoAutomovel>();
			servicos.AddTransient<IValidadorAutomovel, ValidadorAutomovel>();
            servicos.AddTransient<IRepositorioAutomovel, RepositorioAutomovelEmOrm>();

            servicos.AddTransient<ControladorCliente>();
			servicos.AddTransient<ServicoCliente>();
			servicos.AddTransient<IValidadorCliente, ValidadorCliente>();
			servicos.AddTransient<IRepositorioCliente, RepositorioClienteEmOrm>();

			////TODO
			//servicos.AddTransient<ControladorCliente>();--------------------> Condutor
			//servicos.AddTransient<ServicoCliente>();
			//servicos.AddTransient<IValidadorCliente, ValidadorCliente>();
			//servicos.AddTransient<IRepositorioCliente, RepositorioClienteEmOrm>();

			servicos.AddTransient<ControladorCupom>();
			servicos.AddTransient<ServicoCupom>();
			servicos.AddTransient<IValidadorCupom, ValidadorCupom>();
			servicos.AddTransient<IRepositorioCupom, RepositorioCupomEmOrm>();

			servicos.AddTransient<ControladorFuncionario>();
			servicos.AddTransient<ServicoFuncionario>();
			servicos.AddTransient<IValidadorFuncionario, ValidadorFuncionario>();
			servicos.AddTransient<IRepositorioFuncionario, RepositorioFuncionarioEmOrm>();

			servicos.AddTransient<ControladorGrupoDeAutomoveis>();
			servicos.AddTransient<ServicoGrupoDeAutomoveis>();
			servicos.AddTransient<IValidadorGrupoDeAutomoveis, ValidadorGrupoDeAutomoveis>();
			servicos.AddTransient<IRepositorioGrupoDeAutomoveis, RepositorioGrupoDeAutomoveisOrm>();

			servicos.AddTransient<ControladorParceiro>();
			servicos.AddTransient<ServicoParceiro>();
			servicos.AddTransient<IValidadorParceiro, ValidadorParceiro>();
			servicos.AddTransient<IRepositorioParceiro, RepositorioParceiroEmOrm>();

			servicos.AddTransient<ControladorPlanoDeCobranca>();
			servicos.AddTransient<ServicoPlanoDeCobranca>();
			servicos.AddTransient<IValidadorPlanoDeCobranca, ValidadorPlanoDeCobranca>();
			servicos.AddTransient<IRepositorioPlanoDeCobranca, RepositorioPlanoDeCobrancaEmOrm>();

			servicos.AddTransient<ControladorTaxaOuServico>();
			servicos.AddTransient<ServicoTaxaOuServico>();
			servicos.AddTransient<IValidadorTaxaOuServico, ValidadorTaxaOuServico>();
			servicos.AddTransient<IRepositorioTaxaOuServico, RepositorioTaxaOuServicoEmOrm>();


			servicos.AddTransient<ContextoDados>(provider =>
			{
				bool carregarDados = true;
				return new ContextoDados(carregarDados);
			});
			servicos.AddTransient<ControladorTaxaOuServico>();
			servicos.AddTransient<ServicoConfiguracaoDePrecos>();
			servicos.AddTransient<IValidadorConfiguracaoDePrecos, ValidadorConfiguracaoDePrecos>();
			servicos.AddTransient<IRepositorioConfiguracaoDePrecos, RepositorioConfiguracaoDePrecosEmArquivo>();

			container = servicos.BuildServiceProvider();
		}


		public T? Get<T>()
		{
			return container.GetService<T>();
		}
	}
}
