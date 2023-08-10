using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;

namespace LocadoraDeAutomoveis.WinApp.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase
    {
        private IRepositorioAluguel RepositorioAluguel { get; set; }
        private IRepositorioAutomovel RepositorioAutomovel { get; set; }
        private IRepositorioFuncionario RepositorioFuncionario { get; set; }
        private IRepositorioCliente RepositorioCliente { get; set; }
        private IRepositorioGrupoDeAutomoveis RepositorioGrupo { get; set; }
        private IRepositorioPlanoDeCobranca RepositorioPlano { get; set; }
        private IRepositorioCondutor RepositorioCondutor { get; set; }
        private IRepositorioTaxaOuServico RepositorioTaxa { get; set; }
        private ServicoAluguel ServicoAluguel { get; set; }
        private TabelaAluguel? TabelaAluguel { get; set; }

        public ControladorAluguel(IRepositorioAluguel repositorioAluguel, IRepositorioAutomovel repositorioAutomovel, IRepositorioFuncionario repositorioFuncionario, IRepositorioCliente repositorioCliente, IRepositorioGrupoDeAutomoveis repositorioGrupo, IRepositorioPlanoDeCobranca repositorioPlano, IRepositorioCondutor repositorioCondutor, IRepositorioTaxaOuServico repositorioTaxa, ServicoAluguel servicoAluguel, TabelaAluguel? tabelaAluguel)
        {
            RepositorioAluguel = repositorioAluguel;
            RepositorioAutomovel = repositorioAutomovel;
            RepositorioFuncionario = repositorioFuncionario;
            RepositorioCliente = repositorioCliente;
            RepositorioGrupo = repositorioGrupo;
            RepositorioPlano = repositorioPlano;
            RepositorioCondutor = repositorioCondutor;
            RepositorioTaxa = repositorioTaxa;
            ServicoAluguel = servicoAluguel;
            TabelaAluguel = tabelaAluguel;
        }

        public override void Inserir()
        {
            List<Automovel> automoveis = SelecionarAutomoveisSemAluguel();
            List<Funcionario> funcionarios = RepositorioFuncionario.SelecionarTodos();
            List<Cliente> clientes = RepositorioCliente.SelecionarTodos();
            List<GrupoDeAutomoveis> grupos = SelecionarGruposComPlano();
            List<PlanoDeCobranca> planos = RepositorioPlano.SelecionarTodos();
            List<Condutor> condutores = RepositorioCondutor.SelecionarTodos();
            List<TaxaOuServico> taxas = RepositorioTaxa.SelecionarTodos();

            DialogAluguel dialog = new DialogAluguel(funcionarios, clientes, grupos, planos, condutores, automoveis, taxas);

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
                                $"Edição de Alugueis",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                return;
            }

            List<Automovel> automoveis = SelecionarAutomoveisSemAluguel();
            List<Funcionario> funcionarios = RepositorioFuncionario.SelecionarTodos();
            List<Cliente> clientes = RepositorioCliente.SelecionarTodos();
            List<GrupoDeAutomoveis> grupos = RepositorioGrupo.SelecionarTodos();
            List<PlanoDeCobranca> planos = RepositorioPlano.SelecionarTodos();
            List<Condutor> condutores = RepositorioCondutor.SelecionarTodos();
            List<TaxaOuServico> taxas = RepositorioTaxa.SelecionarTodos();

            DialogAluguel dialog = new DialogAluguel(funcionarios, clientes, grupos, planos, condutores, automoveis, taxas);

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
                                $"Exclusão de Alugueis",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                return;
            }

            if (registro.Aberto == true)
            {
                MessageBox.Show($"O Aluguel precisa estar fechado para poder excluir!",
                                $"Exclusão de Alugueis",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcao = MessageBox.Show($"Deseja excluir o {ObtemConfiguracaoToolbox().TipoEntidade}?",
                                                          $"Exclusão de Alugueis",
                                                          MessageBoxButtons.OKCancel,
                                                          MessageBoxIcon.Question);

            if (opcao == DialogResult.OK)
            {
                Result resultado = ServicoAluguel.Excluir(registro);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, $"Exclusão de Alugueis",
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

            mensagemRodape = string.Format("Visualizando {0} alugue{1}", registros.Count, registros.Count == 1 ? "l" : "is");

            TelaPrincipalForm.Instancia!.AtualizarRodape(mensagemRodape);
        }

        private List<Automovel> SelecionarAutomoveisSemAluguel()
        {
            List<Automovel> automoveis = RepositorioAutomovel.SelecionarTodos();

            List<Automovel> automoveisSemAluguel = new List<Automovel>();

            foreach (Automovel g in automoveis)
            {
                if (g.Aluguel == null)
                {
                    automoveisSemAluguel.Add(g);
                }
            }

            return automoveisSemAluguel;
        }

        private List<GrupoDeAutomoveis> SelecionarGruposComPlano()
        {
            List<GrupoDeAutomoveis> grupos = RepositorioGrupo.SelecionarTodos();

            List<GrupoDeAutomoveis> gruposComPlano = new List<GrupoDeAutomoveis>();

            foreach (GrupoDeAutomoveis g in grupos)
            {
                if (g.PlanoDeCobranca != null)
                {
                    gruposComPlano.Add(g);
                }
            }

            return gruposComPlano;
        }
    }
}
