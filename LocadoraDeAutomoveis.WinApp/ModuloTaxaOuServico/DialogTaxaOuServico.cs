using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.WinApp.Compartilhado;

namespace LocadoraDeAutomoveis.WinApp.ModuloTaxaOuServico
{
	public partial class DialogTaxaOuServico : Form
	{
		private TaxaOuServico? taxaOuServico;

		public event GravarRegistroDelegate<TaxaOuServico>? onGravarRegistro;
		public DialogTaxaOuServico()
		{
			InitializeComponent();
			this.ConfigurarDialog();
		}

		public TaxaOuServico TaxaOuServico
		{
			set
			{
				taxaOuServico = value;
				txtNome.Text = taxaOuServico.Nome;
				numericUpDownPreco.Value = taxaOuServico.Preco;

				if (taxaOuServico.TipoCobranca == TaxaOuServico.TipoDeCobranca.PrecoFixo)
				{
					radioButtonPrecoFixo.Checked = true;
				}
				else
				{
					radioButtonCobrancaDiaria.Checked = true;
				}
			}
			get
			{
				taxaOuServico!.Nome = txtNome.Text;
				taxaOuServico.Preco = (decimal)numericUpDownPreco.Value;

				if (radioButtonPrecoFixo.Checked == true)
				{
					taxaOuServico.TipoCobranca = TaxaOuServico.TipoDeCobranca.PrecoFixo;
				}
				else
				{
					taxaOuServico.TipoCobranca = TaxaOuServico.TipoDeCobranca.CobrancaDiaria;
				}

				return taxaOuServico;
			}
		}

		private void btnGravar_Click(object sender, EventArgs e)
		{
			Result resultado = onGravarRegistro!(TaxaOuServico);

			if (resultado.IsFailed)
			{
				string erro = resultado.Errors[0].Message;

				TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

				DialogResult = DialogResult.None;
			}
		}
	}
}
