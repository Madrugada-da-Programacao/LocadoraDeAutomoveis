﻿using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.WinApp.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobranca : ControladorBase
    {
        private IRepositorioPlanoDeCobranca RepositorioPlanoDeCobranca { get; set; }
        private ServicoPlanoDeCobranca ServicoPlanoDeCobranca { get; set; }
        private TabelaPlanoDeCobranca? TabelaPlanoDeCobranca { get; set; }

        public ControladorPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca, ServicoPlanoDeCobranca servicoPlanoDeCobranca)
        {
            RepositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
            ServicoPlanoDeCobranca = servicoPlanoDeCobranca;
        }

        public override void Inserir()
        {
            DialogPlanoDeCobranca dialog = new DialogPlanoDeCobranca();

            dialog.onGravarRegistro += ServicoPlanoDeCobranca.Inserir;

            dialog.PlanoDeCobranca = new PlanoDeCobranca();

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarEntidades();
            }
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
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

            mensagemRodape = string.Format("Visualizando {0} PlanoDeCobranca{1}", registros.Count, registros.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia!.AtualizarRodape(mensagemRodape);
        }
    }
}
