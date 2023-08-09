using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Infra.Dados.Arquivo.Compartilhado;
using LocadoraDeAutomoveis.Infra.Dados.Arquivo.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.WinApp.ModuloCliente;
using LocadoraDeAutomoveis.WinApp.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.WinApp.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.WinApp.ModuloConfiguracaoDePreco;
using LocadoraDeAutomoveis.WinApp.ModuloFuncionario;
using LocadoraDeAutomoveis.WinApp.ModuloParceiro;
using LocadoraDeAutomoveis.WinApp.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.WinApp.Compartilhado.IoC;
using LocadoraDeAutomoveis.WinApp.ModuloAutomovel;

namespace LocadoraDeAutomoveis.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase? controlador { get; set; }
		private IoC IoC { get; set; }

		public TelaPrincipalForm()
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;

			IoC = new IoC_ComInjecaoDependencia();
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
            ConfigurarTelaPrincipal(IoC.Get<ControladorAutomovel>());
        }

        private void clienteMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorCliente>());
        }

        private void condutorMenuItem_Click(object sender, EventArgs e)
        {
            //ConfigurarTelaPrincipal(controladores["ControladorDisciplina"]);
        }

        private void funcionarioMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorFuncionario>());
        }

        private void grupoDeAutomoveisMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorGrupoDeAutomoveis>());
        }

        private void taxasOuServicosMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorTaxaOuServico>());
        }

        private void parceiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorParceiro>());
        }

        private void planoDeCobrancaMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorPlanoDeCobranca>());
        }

        private void configurarPrecosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO tentar passar isso para o IoC
            ContextoDados contexto = new ContextoDados(carregarDados: true);
            IRepositorioConfiguracaoDePrecos RepositorioConfiguracaoDePrecos = new RepositorioConfiguracaoDePrecosEmArquivo(contexto);
            ValidadorConfiguracaoDePrecos ValidadorConfiguracaoDePrecos = new ValidadorConfiguracaoDePrecos();
            ServicoConfiguracaoDePrecos ServicoConfiguracaoDePrecos = new ServicoConfiguracaoDePrecos(RepositorioConfiguracaoDePrecos, ValidadorConfiguracaoDePrecos);

			//TODO tentar passar isso para o IoC
			//ConfiguracaoDePrecos registro = IoC.Get<RepositorioConfiguracaoDePrecosEmArquivo>()!.SelecionarRegistro();
			ConfiguracaoDePrecos registro = RepositorioConfiguracaoDePrecos.SelecionarRegistro();

			DialogConfiguracaoDePrecos dialog = new DialogConfiguracaoDePrecos();

			//TODO tentar passar isso para o IoC
			//dialog.onGravarRegistro += IoC.Get<ServicoConfiguracaoDePrecos>()!.Editar;
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

        private void ConfigurarTelaPrincipal(ControladorBase? controlador)
        {
            this.controlador = controlador;

            ConfigurarToolbox();

            ConfigurarListagem();

            string mensagemRodape = controlador!.ObterMensagemRodape();

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