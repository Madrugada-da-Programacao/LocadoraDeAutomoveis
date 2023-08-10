using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.WinApp.ModuloTaxaOuServico;

namespace LocadoraDeAutomoveis.WinApp.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobranca : ControladorBase
    {
        private IRepositorioPlanoDeCobranca RepositorioPlanoDeCobranca { get; set; }
        private IRepositorioGrupoDeAutomoveis RepositorioGrupoDeAutomoveis { get; set; }
        private ServicoPlanoDeCobranca ServicoPlanoDeCobranca { get; set; }
        private TabelaPlanoDeCobranca? TabelaPlanoDeCobranca { get; set; }

        public ControladorPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca, ServicoPlanoDeCobranca servicoPlanoDeCobranca, IRepositorioGrupoDeAutomoveis repositorioGrupoDeAutomoveis)
        {
            RepositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
            ServicoPlanoDeCobranca = servicoPlanoDeCobranca;
            RepositorioGrupoDeAutomoveis = repositorioGrupoDeAutomoveis;
        }

        public override void Inserir()
        {
            List<GrupoDeAutomoveis> grupos = SelecionarGruposDeAutomoveis();

            DialogPlanoDeCobranca dialog = new DialogPlanoDeCobranca(grupos);

            dialog.onGravarRegistro += ServicoPlanoDeCobranca.Inserir;

            dialog.PlanoDeCobranca = new PlanoDeCobranca();

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarEntidades();
            }
        }

        public override void Editar()
        {
            Guid idRegistro = TabelaPlanoDeCobranca!.ObtemIdSelecionado();
            PlanoDeCobranca? registro = RepositorioPlanoDeCobranca.SelecionarPorId(idRegistro);

            if (registro == null)
            {
                MessageBox.Show($"Selecione um {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
                                $"Edição de Planos de Cobrança",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                return;
            }

            List<GrupoDeAutomoveis> grupos = SelecionarGruposDeAutomoveis();

            DialogPlanoDeCobranca dialog = new DialogPlanoDeCobranca(grupos);

            dialog.onGravarRegistro += ServicoPlanoDeCobranca.Editar;

            dialog.PlanoDeCobranca = registro;

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarEntidades();
            }
        }

        public override void Excluir()
        {
            Guid idRegistro = TabelaPlanoDeCobranca!.ObtemIdSelecionado();
            PlanoDeCobranca? registro = RepositorioPlanoDeCobranca.SelecionarPorId(idRegistro);

            if (registro == null)
            {
                MessageBox.Show($"Selecione um {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
                                $"Exclusão de Planos de Cobrança",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcao = MessageBox.Show($"Deseja excluir o {ObtemConfiguracaoToolbox().TipoEntidade}?",
                                                          $"Exclusão de Planos de Cobrança",
                                                          MessageBoxButtons.OKCancel,
                                                          MessageBoxIcon.Question);

            if (opcao == DialogResult.OK)
            {
                Result resultado = ServicoPlanoDeCobranca.Excluir(registro);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, $"Exclusão de Planos de Cobrança",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarEntidades();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPlanoDeCobranca();
        }

        public override UserControl ObtemListagem()
        {
            TabelaPlanoDeCobranca ??= new TabelaPlanoDeCobranca();

            CarregarEntidades();

            return TabelaPlanoDeCobranca;
        }

        private void CarregarEntidades()
        {
            List<PlanoDeCobranca> registros = RepositorioPlanoDeCobranca.SelecionarTodos();

            TabelaPlanoDeCobranca!.AtualizarRegistros(registros);

            mensagemRodape = string.Format("Visualizando {0} Plano{1} de Cobranca", registros.Count, registros.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia!.AtualizarRodape(mensagemRodape);
        }

        private List<GrupoDeAutomoveis> SelecionarGruposDeAutomoveis()
        {
            List<GrupoDeAutomoveis> grupo = new List<GrupoDeAutomoveis>();

            grupo = RepositorioGrupoDeAutomoveis.SelecionarTodos();

            return grupo;
        }
    }
}
