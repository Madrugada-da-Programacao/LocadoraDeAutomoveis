using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.WinApp.Compartilhado;

namespace LocadoraDeAutomoveis.WinApp.ModuloGrupoDeAutomoveis
{
	public partial class DialogGrupoDeAutomoveis : Form
	{
		private GrupoDeAutomoveis? grupoDeAutomoveis;

		public event GravarRegistroDelegate<GrupoDeAutomoveis>? onGravarRegistro;
		public DialogGrupoDeAutomoveis()
		{
			InitializeComponent();
			this.ConfigurarDialog();
		}

		public GrupoDeAutomoveis GrupoDeAutomoveis
		{
			set
			{
				grupoDeAutomoveis = value;
				txtNome.Text = grupoDeAutomoveis.Nome;
			}
			get
			{
				grupoDeAutomoveis!.Nome = txtNome.Text;

				return grupoDeAutomoveis;
			}
		}

		private void btnGravar_Click(object sender, EventArgs e)
		{
			Result resultado = onGravarRegistro!(GrupoDeAutomoveis);

			if (resultado.IsFailed)
			{
				string erro = resultado.Errors[0].Message;

				TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

				DialogResult = DialogResult.None;
			}
		}
	}
}
