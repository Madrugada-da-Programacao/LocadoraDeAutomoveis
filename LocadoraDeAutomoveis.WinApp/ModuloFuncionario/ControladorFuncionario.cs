using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.WinApp.ModuloFuncionario
{
    internal class ControladorFuncionario : ControladorBase
    {
        private IRepositorioFuncionario? RepositorioFuncionario { get; set; }
        private ServicoFuncionario? ServicoFuncionario { get; set; }
        private TabelaFuncionario? TabelaFuncionario { get; set; }

        public ControladorFuncionario(IRepositorioFuncionario repositorioFuncionario, ServicoFuncionario servicoFuncionario)
        {
            RepositorioFuncionario = repositorioFuncionario;
            ServicoFuncionario = servicoFuncionario;
        }

        public override void Inserir()
        {
            DialogFuncionario dialog = new DialogFuncionario();

            dialog.onGravarRegistro += ServicoFuncionario!.Inserir;

            Funcionario funcionario = new Funcionario();

            dialog.Funcionario = funcionario;

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarEntidades();
            }
        }

        public override void Editar()
        {
            Guid idRegistro = TabelaFuncionario!.ObtemIdSelecionado();
            Funcionario? registro = RepositorioFuncionario!.SelecionarPorId(idRegistro);

            if (registro == null)
            {
                MessageBox.Show($"Selecione uma {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
                                $"Edição de {ObtemConfiguracaoToolbox().TipoEntidade}s",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                return;
            }

            DialogFuncionario dialog = new DialogFuncionario();

            dialog.onGravarRegistro += ServicoFuncionario!.Editar;

            dialog.Funcionario = registro;

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarEntidades();
            }
        }

        public override void Excluir()
        {
            Guid idRegistro = TabelaFuncionario!.ObtemIdSelecionado();
            Funcionario? registro = RepositorioFuncionario!.SelecionarPorId(idRegistro);

            if (registro == null)
            {
                MessageBox.Show($"Selecione um {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
                                $"Exclusão de {ObtemConfiguracaoToolbox().TipoEntidade}s",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcao = MessageBox.Show($"Deseja excluir a {ObtemConfiguracaoToolbox().TipoEntidade}?",
                                                          $"Exclusão de {ObtemConfiguracaoToolbox().TipoEntidade}s",
                                                          MessageBoxButtons.OKCancel,
                                                          MessageBoxIcon.Question);

            if (opcao == DialogResult.OK)
            {
                Result resultado = ServicoFuncionario!.Excluir(registro);

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
            return new ConfiguracaoToolboxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            TabelaFuncionario ??= new TabelaFuncionario();

            CarregarEntidades();

            return TabelaFuncionario;
        }

        private void CarregarEntidades()
        {
            List<Funcionario> registros = RepositorioFuncionario!.SelecionarTodos();

            TabelaFuncionario!.AtualizarRegistros(registros);

            mensagemRodape = string.Format("Visualizando {0} funcionario{1}", registros.Count, registros.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia!.AtualizarRodape(mensagemRodape);
        }
    }
}
