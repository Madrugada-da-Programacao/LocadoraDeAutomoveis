using LocadoraDeAutomoveis.Dominio.ModuloCupom;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloParceiro;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.WinApp.ModuloCupom
{
	public partial class DialogCupom : Form
	{
		private Cupom? cupom;

		public event GravarRegistroDelegate<Cupom>? onGravarRegistro;

		public DialogCupom(List<Parceiro> registros)
		{
			InitializeComponent();
			this.ConfigurarDialog();

			comboBoxParceiro.DisplayMember = "Nome";
			comboBoxParceiro.DataSource = registros;
		}

		public Cupom Cupom
		{
			set
			{
				cupom = value;
				txtNome.Text = cupom.Nome;
				numericUpDownPreco.Value = cupom.Preco;
				dateTimePickerDataDeValidade.Value = cupom.DataValidade;
				if (cupom.Parceiro != null)
					comboBoxParceiro.SelectedItem = cupom.Parceiro;
			}
			get
			{
				cupom!.Nome = txtNome.Text;
				cupom.Preco = (decimal)numericUpDownPreco.Value;
				cupom.DataValidade = dateTimePickerDataDeValidade.Value;
				cupom!.Parceiro = (Parceiro)comboBoxParceiro.SelectedItem;

				return cupom;
			}
		}

		private void btnGravar_Click(object sender, EventArgs e)
		{
			Result resultado = onGravarRegistro!(Cupom);

			if (resultado.IsFailed)
			{
				string erro = resultado.Errors[0].Message;

				TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

				DialogResult = DialogResult.None;
			}
		}
	}
}
