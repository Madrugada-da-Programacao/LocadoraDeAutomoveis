using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloParceiro;
using LocadoraDeAutomoveis.WinApp.Compartilhado;

namespace LocadoraDeAutomoveis.WinApp.ModuloParceiro
{
	public partial class DialogParceiro : Form
	{
		private Parceiro? parceiro;

		public event GravarRegistroDelegate<Parceiro>? onGravarRegistro;
		public DialogParceiro()
		{
			InitializeComponent();
			this.ConfigurarDialog();
		}

		public Parceiro Parceiro
		{
			set
			{
				parceiro = value;
				txtNome.Text = parceiro.Nome;
			}
			get
			{
				parceiro!.Nome = txtNome.Text;

				return parceiro;
			}
		}

		private void btnGravar_Click(object sender, EventArgs e)
		{
			Result resultado = onGravarRegistro!(Parceiro);

			if (resultado.IsFailed)
			{
				string erro = resultado.Errors[0].Message;

				TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

				DialogResult = DialogResult.None;
			}
		}
	}
}
