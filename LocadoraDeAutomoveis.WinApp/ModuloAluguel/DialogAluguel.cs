using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloCupom;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.Infra.Orm.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca.PlanoDeCobranca;

namespace LocadoraDeAutomoveis.WinApp.ModuloAluguel
{
    public partial class DialogAluguel : Form
    {
        private Aluguel? aluguel;
        public event GravarRegistroDelegate<Aluguel>? onGravarRegistro;
        private List<TaxaOuServico> Taxas { get; set; }
        private List<Cupom> Cupoms { get; set; }
        private decimal ValorTotal { get; set; }
        public DialogAluguel(List<Funcionario> funcionarios, List<Cliente> clientes, List<GrupoDeAutomoveis> grupos, List<PlanoDeCobranca> planos, List<Condutor> condutores, List<Automovel> automoveis, List<TaxaOuServico> taxas)
        {
            InitializeComponent();
            this.ConfigurarDialog();

            cmbFuncionario.DataSource = funcionarios;

            cmbCliente.DataSource = clientes;

            cmbGrupoAutomoveis.DataSource = grupos;

            cmbCondutor.DataSource = condutores;

            cmbAutomovel.DataSource = automoveis;

            Taxas = taxas;

            AdicionarTaxas(taxas);

            AdicionarTipoDoPlanoEnum();
        }

        private void AdicionarTipoDoPlanoEnum()
        {
            TipoDoPlanoEnum[] TiposDePlano = Enum.GetValues<TipoDoPlanoEnum>();

            foreach (TipoDoPlanoEnum t in TiposDePlano)
            {
                cmbPlanoCobranca.Items.Add(t);
            }
        }

        private void AdicionarTaxas(List<TaxaOuServico> taxas)
        {
            foreach (TaxaOuServico t in taxas)
            {
                listTaxas.Items.Add(t);
            }
        }

        //Não pode deixar alugar um carro que está alugado

        /*O preço da locação levará em consideração:
          O plano selecionado
          A quantidade de dias
          Quilometragem percorrida(dependendo do plano)
          Preço do Km
          As taxas selecionadas, caso necessário
          Aplicar valor do cupom, caso necessário

          Validar:
          Se o veículo está disponível;
          Se os documentos estão em dia*/


        public Aluguel Aluguel
        {
            set
            {
                aluguel = value;

                cmbFuncionario.SelectedItem = aluguel.Funcionario;
                cmbCliente.SelectedItem = aluguel.Cliente;
                cmbGrupoAutomoveis.SelectedItem = aluguel.GrupoDeAutomoveis;
                cmbPlanoCobranca.SelectedItem = aluguel.TipoDoPlano;
                cmbCondutor.SelectedItem = aluguel.Condutor;
                cmbAutomovel.SelectedItem = aluguel.Automovel;
                txtDataLocacao.Value = aluguel.DataLocacao;
                txtDataDevolucaoPrevista.Value = aluguel.DataDevolucaoPrevista;
                txtKmAutomovel.Value = Convert.ToDecimal(aluguel.Automovel.KM);
                ValorTotal = Aluguel.ValorTotal;

                for (int i = 0; i < Taxas.Count; i++)
                {
                    if (aluguel.Taxas.Any(x => x.Id == Taxas[i].Id))
                        listTaxas.SetItemChecked(i, true);
                }

                Cupoms.AddRange(aluguel.Cupoms);
            }
            //funcionario cliente grupoauto planocobr condutor automovel
            // data locação devolucaoprevista kmdoautomovel cupomlist taxas taxasAdicionais valortotal TODO
            get
            {
                aluguel.Funcionario = (Funcionario)cmbFuncionario.SelectedItem;
                aluguel.Cliente = (Cliente)cmbCliente.SelectedItem;
                aluguel.GrupoDeAutomoveis = (GrupoDeAutomoveis)cmbGrupoAutomoveis.SelectedItem;
                aluguel.TipoDoPlano = (TipoDoPlanoEnum)cmbPlanoCobranca.SelectedItem;
                aluguel.Condutor = (Condutor)cmbCondutor.SelectedItem;
                aluguel.Automovel = (Automovel)cmbAutomovel.SelectedItem;
                aluguel.DataLocacao = txtDataLocacao.Value;
                aluguel.DataDevolucaoPrevista = txtDataDevolucaoPrevista.Value;
                aluguel.Automovel.KM = (float)txtKmAutomovel.Value;
                aluguel.Taxas = listTaxas.SelectedItems.Cast<TaxaOuServico>().ToList();
                aluguel.ValorTotal = ValorTotal;

                return aluguel;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Result resultado = onGravarRegistro!(Aluguel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnCupom_Click(object sender, EventArgs e)
        {
            AtualizarValorTotal();
        }

        private void AtualizarValorTotal()
        {
            //       O preço da locação levará em consideração:
            //       O plano selecionado
            //       A quantidade de dias
            //       Quilometragem percorrida(dependendo do plano)
            //      Preço do Km
            //      As taxas selecionadas, caso necessário
            //      Aplicar valor do cupom, caso necessário

           /* ValorTotal = 0m;
            if ((TipoDoPlanoEnum)cmbPlanoCobranca.SelectedItem == TipoDoPlanoEnum.PlanoDiario)
            {
                GrupoDeAutomoveis grupo = (GrupoDeAutomoveis)cmbGrupoAutomoveis.SelectedItem;
                ValorTotal += Convert.ToDecimal(txtDataDevolucaoPrevista.Value - txtDataLocacao.Value) * grupo.PlanoDeCobranca.PrecoDiariaPlanoDiario + txtKmAutomovel.Value * grupo.PlanoDeCobranca.PrecoKmPlanoDiario;
            }
            if ((TipoDoPlanoEnum)cmbPlanoCobranca.SelectedItem == TipoDoPlanoEnum.KmControlado)
            {
                GrupoDeAutomoveis grupo = (GrupoDeAutomoveis)cmbGrupoAutomoveis.SelectedItem;
                if (txtKmAutomovel.Value / Convert.ToDecimal(txtDataDevolucaoPrevista.Value - txtDataLocacao.Value) > grupo.PlanoDeCobranca.KmDisponiveisKmControlado)
                ValorTotal += txtKmAutomovel.Value / Convert.ToDecimal(txtDataDevolucaoPrevista.Value - txtDataLocacao.Value) * grupo.PlanoDeCobranca.PrecoDiariaPlanoDiario + * grupo.PlanoDeCobranca.PrecoKmExtrapoladoKmControlado
            }
            if ((TipoDoPlanoEnum)cmbPlanoCobranca.SelectedItem == TipoDoPlanoEnum.KmControlado)
            { }
            
            */

        }
    }
}
