using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.WinApp.ModuloGrupoDeAutomoveis
{
    public class ControladorGrupoDeAutomoveis : ControladorBase
    {
        private IRepositorioGrupoDeAutomoveis repositorioGrupoDeAutomoveis { get; set; }
        private ServicoGrupoDeAutomoveis servicoGrupoDeAutomoveis { get; set; }
        private TabelaGrupoDeAutomoveis tabelaGrupoDeAutomoveis { get; set; }

        public ControladorGrupoDeAutomoveis(IRepositorioGrupoDeAutomoveis repositorioGrupoDeAutomoveis, ServicoGrupoDeAutomoveis servicoGrupoDeAutomoveis)
        {
            this.repositorioGrupoDeAutomoveis = repositorioGrupoDeAutomoveis;
            this.servicoGrupoDeAutomoveis = servicoGrupoDeAutomoveis;
        }

        public override void Inserir()
        {
            DialogGrupoDeAutomoveis dialog = new DialogGrupoDeAutomoveis();

            dialog.onGravarRegistro += servicoGrupoDeAutomoveis.Inserir;

            dialog.GrupoDeAutomoveis = new GrupoDeAutomoveis();

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarEntidades();
            }
        }

        public override void Editar()
        {
            Guid idRegistro = tabelaGrupoDeAutomoveis.ObtemIdSelecionado();
            GrupoDeAutomoveis? registro = repositorioGrupoDeAutomoveis.SelecionarPorId(idRegistro);

            if (registro == null)
            {
                MessageBox.Show($"Selecione um {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
                                $"Edição de {ObtemConfiguracaoToolbox().TipoEntidade}s",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                return;
            }

            DialogGrupoDeAutomoveis dialog = new DialogGrupoDeAutomoveis();

            dialog.onGravarRegistro += servicoGrupoDeAutomoveis.Editar;

            dialog.GrupoDeAutomoveis = registro;

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarEntidades();
            }
        }

        public override void Excluir()
        {
            Guid idRegistro = tabelaGrupoDeAutomoveis.ObtemIdSelecionado();
            GrupoDeAutomoveis? registro = repositorioGrupoDeAutomoveis.SelecionarPorId(idRegistro);

            if (registro == null)
            {
                MessageBox.Show($"Selecione um {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
                                $"Exclusão de {ObtemConfiguracaoToolbox().TipoEntidade}s",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcao = MessageBox.Show($"Deseja excluir o {ObtemConfiguracaoToolbox().TipoEntidade} {registro.Nome}?",
                                                          $"Exclusão de {ObtemConfiguracaoToolbox().TipoEntidade}s",
                                                          MessageBoxButtons.OKCancel,
                                                          MessageBoxIcon.Question);

            if (opcao == DialogResult.OK)
            {
                Result resultado = servicoGrupoDeAutomoveis.Excluir(registro);

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
            return new ConfiguracaoToolboxGrupoDeAutomoveis();
        }

        public override UserControl ObtemListagem()
        {
            tabelaGrupoDeAutomoveis ??= new TabelaGrupoDeAutomoveis();

            CarregarEntidades();

            return tabelaGrupoDeAutomoveis;
        }

        private void CarregarEntidades()
        {
            List<GrupoDeAutomoveis> registros = repositorioGrupoDeAutomoveis.SelecionarTodos();

            tabelaGrupoDeAutomoveis.AtualizarRegistros(registros);

            mensagemRodape = string.Format("Visualizando {0} cliente{1}", registros.Count, registros.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
