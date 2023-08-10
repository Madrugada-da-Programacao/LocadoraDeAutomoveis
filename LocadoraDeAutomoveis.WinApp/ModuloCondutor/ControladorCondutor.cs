using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraDeAutomoveis.WinApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
	{
		private IRepositorioCondutor RepositorioCondutor { get; set; }
        private IRepositorioCliente RepositorioCliente { get; set; }
        private ServicoCondutor ServicoCondutor { get; set; }
        private TabelaCondutor? TabelaCondutor { get; set; }

        public ControladorCondutor(IRepositorioCondutor repositorioCondutor, ServicoCondutor servicoCondutor, IRepositorioCliente repositorioCliente)
        {
            RepositorioCondutor = repositorioCondutor;
            ServicoCondutor = servicoCondutor;
            RepositorioCliente = repositorioCliente;
        }

        public override void Inserir()
        {
            List<Cliente> clientes = RepositorioCliente.SelecionarTodos();

            DialogCondutor dialog = new DialogCondutor(clientes);

            dialog.onGravarRegistro += ServicoCondutor.Inserir;

            dialog.Condutor = new Condutor();

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarEntidades();
            }
        }

        public override void Editar()
        {
            Guid idRegistro = TabelaCondutor!.ObtemIdSelecionado();
            Condutor? registro = RepositorioCondutor.SelecionarPorId(idRegistro);

            if (registro == null)
            {
                MessageBox.Show($"Selecione um {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
                                $"Edição de {ObtemConfiguracaoToolbox().TipoEntidade}es",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                return;
            }

            List<Cliente> clientes = RepositorioCliente.SelecionarTodos();

            DialogCondutor dialog = new DialogCondutor(clientes);

            dialog.onGravarRegistro += ServicoCondutor.Editar;

            dialog.Condutor = registro;

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarEntidades();
            }
        }

        public override void Excluir()
        {
            Guid idRegistro = TabelaCondutor!.ObtemIdSelecionado();
            Condutor? registro = RepositorioCondutor.SelecionarPorId(idRegistro);

            if (registro == null)
            {
                MessageBox.Show($"Selecione um {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
                                $"Exclusão de {ObtemConfiguracaoToolbox().TipoEntidade}es",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcao = MessageBox.Show($"Deseja excluir o {ObtemConfiguracaoToolbox().TipoEntidade}?",
                                                          $"Exclusão de {ObtemConfiguracaoToolbox().TipoEntidade}es",
                                                          MessageBoxButtons.OKCancel,
                                                          MessageBoxIcon.Question);

            if (opcao == DialogResult.OK)
            {
                Result resultado = ServicoCondutor.Excluir(registro);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, $"Exclusão de {ObtemConfiguracaoToolbox().TipoEntidade}s",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarEntidades();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            TabelaCondutor ??= new TabelaCondutor();

            CarregarEntidades();

            return TabelaCondutor;
        }

        private void CarregarEntidades()
        {
            List<Condutor> registros = RepositorioCondutor.SelecionarTodos();

            TabelaCondutor!.AtualizarRegistros(registros);

            mensagemRodape = string.Format("Visualizando {0} condutor{1}", registros.Count, registros.Count == 1 ? "" : "es");

            TelaPrincipalForm.Instancia!.AtualizarRodape(mensagemRodape);
        }
    }
}
