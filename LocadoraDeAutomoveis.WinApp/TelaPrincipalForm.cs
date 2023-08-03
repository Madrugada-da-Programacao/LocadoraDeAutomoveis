using LocadoraDeAutomoveis.Aplicacao.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Infra.Orm.Compartilhado;
using LocadoraDeAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraDeAutomoveis.WinApp.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeAutomoveis.WinApp
{
	public partial class TelaPrincipalForm : Form
	{
		private Dictionary<string, ControladorBase> controladores;

		private ControladorBase controlador;

		public TelaPrincipalForm()
		{
			InitializeComponent();

			Instancia = this;

			labelRodape.Text = string.Empty;
			labelTipoCadastro.Text = string.Empty;

			controladores = new Dictionary<string, ControladorBase>();

			ConfigurarControladores();
		}

		private void ConfigurarControladores()
		{
			var configuracao = new ConfigurationBuilder()
			   .SetBasePath(Directory.GetCurrentDirectory())
			   .AddJsonFile("appsettings.json")
			   .Build();

			var connectionString = configuracao.GetConnectionString("SqlServer");

			var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeAutomoveisDbContext>();

			optionsBuilder.UseSqlServer(connectionString);

			var dbContext = new LocadoraDeAutomoveisDbContext(optionsBuilder.Options);

			var migracoesPendentes = dbContext.Database.GetPendingMigrations();

			if (migracoesPendentes.Count() > 0)
			{
				dbContext.Database.Migrate();
			}

			//IRepositorioDisciplina repositorioDisciplina = new RepositorioDisciplinaEmOrm(dbContext);

			//ValidadorDisciplina validadorDisciplina = new ValidadorDisciplina();

			//ServicoDisciplina servicoDisciplina = new ServicoDisciplina(repositorioDisciplina, validadorDisciplina);

			//controladores.Add("ControladorDisciplina", new ControladorDisciplina(repositorioDisciplina, servicoDisciplina));

			//IRepositorioMateria repositorioMateria = new RepositorioMateriaEmOrm(dbContext);

			//ValidadorMateria validadorMateria = new ValidadorMateria();
			//ServicoMateria servicoMateria = new ServicoMateria(repositorioMateria, validadorMateria);

			//controladores.Add("ControladorMateria", new ControladorMateria(repositorioMateria, repositorioDisciplina, servicoMateria));

			//IRepositorioQuestao repositorioQuestao = new RepositorioQuestaoEmOrm(dbContext);

			//ValidadorQuestao validadorQuestao = new ValidadorQuestao();
			//ServicoQuestao servicoQuestao = new ServicoQuestao(repositorioQuestao, validadorQuestao);
			//controladores.Add("ControladorQuestao", new ControladorQuestao(repositorioQuestao, repositorioDisciplina, servicoQuestao));

			//IRepositorioTeste repositorioTeste = new RepositorioTesteEmOrm(dbContext);

			//IGeradorArquivo geradorRelatorio = new GeradorTesteEmPdf();

			//ValidadorTeste validadorTeste = new ValidadorTeste();
			//ServicoTeste servicoTeste = new ServicoTeste(repositorioTeste, repositorioQuestao, validadorTeste, geradorRelatorio);

			//controladores.Add("ControladorTeste", new ControladorTeste(repositorioTeste, repositorioDisciplina, servicoTeste));







			// Usar os modelos de cima como base e inserir o codigo correto abaixo -----------------------------------

			IRepositorioCliente RepositorioCliente = new RepositorioClienteEmOrm(dbContext);
			ValidadorCliente ValidadorCliente = new ValidadorCliente();
			ServicoCliente ServicoCliente = new ServicoCliente(RepositorioCliente, ValidadorCliente);
			controladores.Add("ControladorCliente", new ControladorCliente(RepositorioCliente, ServicoCliente));



		}

		public static TelaPrincipalForm Instancia
		{
			get;
			private set;
		}

		public void AtualizarRodape()
		{
			string mensagemRodape = controlador.ObterMensagemRodape();

			AtualizarRodape(mensagemRodape);
		}

		public void AtualizarRodape(string mensagem)
		{
			labelRodape.Text = mensagem;
		}

		private void aluguelMenuItem_Click(object sender, EventArgs e)
		{
			//ConfigurarTelaPrincipal(controladores["ControladorDisciplina"]);
		}

		private void automovelMenuItem_Click(object sender, EventArgs e)
		{
			//ConfigurarTelaPrincipal(controladores["ControladorDisciplina"]);
		}

		private void clienteMenuItem_Click(object sender, EventArgs e)
		{
			ConfigurarTelaPrincipal(controladores["ControladorCliente"]);
		}

		private void condutorMenuItem_Click(object sender, EventArgs e)
		{
			//ConfigurarTelaPrincipal(controladores["ControladorDisciplina"]);
		}

		private void funcionarioMenuItem_Click(object sender, EventArgs e)
		{
			//ConfigurarTelaPrincipal(controladores["ControladorDisciplina"]);
		}

		private void grupoDeAutomoveisMenuItem_Click(object sender, EventArgs e)
		{
			//ConfigurarTelaPrincipal(controladores["ControladorDisciplina"]);
		}

		private void planoDeCobrancaMenuItem_Click(object sender, EventArgs e)
		{
			//ConfigurarTelaPrincipal(controladores["ControladorDisciplina"]);
		}

		private void taxasEServicosMenuItem_Click(object sender, EventArgs e)
		{
			//ConfigurarTelaPrincipal(controladores["ControladorDisciplina"]);
		}

		private void btnInserir_Click(object sender, EventArgs e)
		{
			controlador.Inserir();
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
			controlador.Editar();
		}

		private void btnExcluir_Click(object sender, EventArgs e)
		{
			controlador.Excluir();
		}

		private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
		{
			btnInserir.Enabled = configuracao.InserirHabilitado;
			btnEditar.Enabled = configuracao.EditarHabilitado;
			btnExcluir.Enabled = configuracao.ExcluirHabilitado;
		}

		private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
		{
			btnInserir.ToolTipText = configuracao.TooltipInserir;
			btnEditar.ToolTipText = configuracao.TooltipEditar;
			btnExcluir.ToolTipText = configuracao.TooltipExcluir;
		}

		private void ConfigurarTelaPrincipal(ControladorBase controlador)
		{
			this.controlador = controlador;

			ConfigurarToolbox();

			ConfigurarListagem();

			string mensagemRodape = controlador.ObterMensagemRodape();

			AtualizarRodape(mensagemRodape);
		}

		private void ConfigurarToolbox()
		{
			ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

			if (configuracao != null)
			{
				toolbox.Enabled = true;

				labelTipoCadastro.Text = configuracao.TipoCadastro;

				ConfigurarTooltips(configuracao);

				ConfigurarBotoes(configuracao);
			}
		}

		private void ConfigurarListagem()
		{
			AtualizarRodape("");

			var listagemControl = controlador.ObtemListagem();

			panelRegistros.Controls.Clear();

			listagemControl.Dock = DockStyle.Fill;

			panelRegistros.Controls.Add(listagemControl);
		}
	}
}