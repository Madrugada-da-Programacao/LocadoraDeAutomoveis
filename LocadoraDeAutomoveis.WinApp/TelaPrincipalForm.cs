using LocadoraDeAutomoveis.Aplicacao.ModuloCliente;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.Infra.Dados.Arquivo.Compartilhado;
using LocadoraDeAutomoveis.Infra.Dados.Arquivo.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Infra.Orm.Compartilhado;
using LocadoraDeAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraDeAutomoveis.Infra.Orm.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.Infra.Orm.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.WinApp.ModuloCliente;
using LocadoraDeAutomoveis.WinApp.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.WinApp.ModuloGrupoDeAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocadoraDeAutomoveis.WinApp.ModuloConfiguracaoDePreco;

namespace LocadoraDeAutomoveis.WinApp
{
	public partial class TelaPrincipalForm : Form
    {
        private Dictionary<string, ControladorBase> controladores { get; set; }

        private ControladorBase? controlador { get; set; }

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

            if (migracoesPendentes.Any())
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

			IRepositorioGrupoDeAutomoveis RepositorioGrupoDeAutomoveis = new RepositorioGrupoDeAutomoveisOrm(dbContext);
			ValidadorGrupoDeAutomoveis ValidadorGrupoDeAutomoveis = new ValidadorGrupoDeAutomoveis();
			ServicoGrupoDeAutomoveis ServicoGrupoDeAutomoveis = new ServicoGrupoDeAutomoveis(RepositorioGrupoDeAutomoveis, ValidadorGrupoDeAutomoveis);
			controladores.Add("ControladorGrupoDeAutomoveis", new ControladorGrupoDeAutomoveis(RepositorioGrupoDeAutomoveis, ServicoGrupoDeAutomoveis));

            IRepositorioTaxaOuServico RepositorioTaxaOuServico = new RepositorioTaxaOuServicoEmOrm(dbContext);
            ValidadorTaxaOuServico ValidadorTaxaOuServico = new ValidadorTaxaOuServico();
            ServicoTaxaOuServico ServicoTaxaOuServico = new ServicoTaxaOuServico(RepositorioTaxaOuServico, ValidadorTaxaOuServico);
            controladores.Add("ControladorTaxaOuServico", new ControladorTaxaOuServico(RepositorioTaxaOuServico, ServicoTaxaOuServico));

        }

        public static TelaPrincipalForm? Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape()
        {
            if (controlador != null)
            {
                string mensagemRodape = controlador!.ObterMensagemRodape();
                AtualizarRodape(mensagemRodape);
            }
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
            ConfigurarTelaPrincipal(controladores["ControladorFuncionario"]);
        }

		private void grupoDeAutomoveisMenuItem_Click(object sender, EventArgs e)
		{
			ConfigurarTelaPrincipal(controladores["ControladorGrupoDeAutomoveis"]);
		}

        private void taxasOuServicosMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorTaxaOuServico"]);
        }

        private void configurarPrecosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContextoDados contexto = new ContextoDados(carregarDados: true);
            IRepositorioConfiguracaoDePrecos RepositorioConfiguracaoDePrecos = new RepositorioConfiguracaoDePrecosEmArquivo(contexto);
            ValidadorConfiguracaoDePrecos ValidadorConfiguracaoDePrecos = new ValidadorConfiguracaoDePrecos();
            ServicoConfiguracaoDePrecos ServicoConfiguracaoDePrecos = new ServicoConfiguracaoDePrecos(RepositorioConfiguracaoDePrecos, ValidadorConfiguracaoDePrecos);

            ConfiguracaoDePrecos registro = RepositorioConfiguracaoDePrecos.SelecionarRegistro();

            DialogConfiguracaoDePrecos dialog = new DialogConfiguracaoDePrecos();

            dialog.onGravarRegistro += ServicoConfiguracaoDePrecos.Editar;

            dialog.ConfiguracaoDePrecos = registro;

            DialogResult resultado = dialog.ShowDialog();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador!.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador!.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador!.Excluir();
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
            ConfiguracaoToolboxBase configuracao = controlador!.ObtemConfiguracaoToolbox();

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

            var listagemControl = controlador!.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }
    }
}