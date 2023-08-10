using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;

/*
namespace LocadoraDeAutomoveis.WinApp.ModuloAluguel
{
    /*public class ControladorAluguel : ControladorBase
    {
        private IRepositorioAluguel RepositorioAluguel { get; set; }
        private ServicoAluguel ServicoAluguel { get; set; }
        private TabelaAluguel? TabelaAluguel { get; set; }

        public ControladorAluguel(IRepositorioAluguel repositorioAluguel, ServicoAluguel servicoAluguel)
        {
            RepositorioAluguel = repositorioAluguel;
            ServicoAluguel = servicoAluguel;
        }
        /*
        public override void Inserir()
        {
            DialogAluguel dialog = new DialogAluguel();

            dialog.onGravarRegistro += ServicoAluguel.Inserir;

            dialog.Aluguel = new Aluguel();

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarEntidades();
            }
        }

        public override void Editar()
        {
            Guid idRegistro = TabelaAluguel!.ObtemIdSelecionado();
            Aluguel? registro = RepositorioAluguel.SelecionarPorId(idRegistro);

            if (registro == null)
            {
                MessageBox.Show($"Selecione um {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
                                $"Edição de {ObtemConfiguracaoToolbox().TipoEntidade}s",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                return;
            }

            DialogAluguel dialog = new DialogAluguel();

            dialog.onGravarRegistro += ServicoAluguel.Editar;

            dialog.Aluguel = registro;

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarEntidades();
            }
        }

        public override void Excluir()
        {
            Guid idRegistro = TabelaAluguel!.ObtemIdSelecionado();
            Aluguel? registro = RepositorioAluguel.SelecionarPorId(idRegistro);

            if (registro == null)
            {
                MessageBox.Show($"Selecione um {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
                                $"Exclusão de {ObtemConfiguracaoToolbox().TipoEntidade}s",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcao = MessageBox.Show($"Deseja excluir o {ObtemConfiguracaoToolbox().TipoEntidade}?",
                                                          $"Exclusão de {ObtemConfiguracaoToolbox().TipoEntidade}s",
                                                          MessageBoxButtons.OKCancel,
                                                          MessageBoxIcon.Question);

            if (opcao == DialogResult.OK)
            {
                Result resultado = ServicoAluguel.Excluir(registro);

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
            return new ConfiguracaoToolboxAluguel();
        }

        public override UserControl ObtemListagem()
        {
            TabelaAluguel ??= new TabelaAluguel();

            CarregarEntidades();

            return TabelaAluguel;
        }

        private void CarregarEntidades()
        {
            List<Aluguel> registros = RepositorioAluguel.SelecionarTodos();

            TabelaAluguel!.AtualizarRegistros(registros);

            mensagemRodape = string.Format("Visualizando {0} cliente{1}", registros.Count, registros.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia!.AtualizarRodape(mensagemRodape);
        }
    }
}
*/