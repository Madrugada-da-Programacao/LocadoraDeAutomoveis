using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.WinApp.ModuloPlanoDeCobranca
{
	public partial class DialogPlanoDeCobranca : Form
	{
		private PlanoDeCobranca? planoDeCobranca;

		public event GravarRegistroDelegate<PlanoDeCobranca>? onGravarRegistro;
		public DialogPlanoDeCobranca(List<GrupoDeAutomoveis> grupos)
		{
			InitializeComponent();
			this.ConfigurarDialog();

			cmbGrupoAutomoveis.DisplayMember = "Nome";
			cmbGrupoAutomoveis.DataSource = grupos;
		}

		public PlanoDeCobranca PlanoDeCobranca
		{
			set
			{
				planoDeCobranca = value;

				if (planoDeCobranca.GrupoDeAutomoveis != null)
					cmbGrupoAutomoveis.SelectedItem = planoDeCobranca.GrupoDeAutomoveis;
				txtPrecoDiariaPlanoDiaria.Value = planoDeCobranca.PrecoDiariaPlanoDiario;
				txtPrecoKmPlanoDiaria.Value = planoDeCobranca.PrecoKmPlanoDiario;
				txtPrecoDiariaKmControlado.Value = planoDeCobranca.PrecoDiariaKmControlado;
				txtPrecoKmKmControlado.Value = planoDeCobranca.PrecoKmExtrapoladoKmControlado;
				txtKmDisponiveisKmControlado.Value = planoDeCobranca.KmDisponiveisKmControlado;
				txtPrecoDiariaKmLivre.Value = planoDeCobranca.PrecoDiariaKmLivre;
			}
			get
			{
				planoDeCobranca!.GrupoDeAutomoveis = (GrupoDeAutomoveis)cmbGrupoAutomoveis.SelectedItem;
				planoDeCobranca.PrecoDiariaPlanoDiario = txtPrecoDiariaPlanoDiaria.Value;
				planoDeCobranca.PrecoKmPlanoDiario = txtPrecoKmPlanoDiaria.Value;
				planoDeCobranca.PrecoDiariaKmControlado = txtPrecoDiariaKmControlado.Value;
				planoDeCobranca.PrecoKmExtrapoladoKmControlado = txtPrecoKmKmControlado.Value;
				planoDeCobranca.KmDisponiveisKmControlado = Convert.ToInt32(txtKmDisponiveisKmControlado.Value);
				planoDeCobranca.PrecoDiariaKmLivre = txtPrecoDiariaKmLivre.Value;

				return planoDeCobranca;
			}
		}

		private void btnGravar_Click(object sender, EventArgs e)
		{
			Result resultado = onGravarRegistro!(PlanoDeCobranca);

			if (resultado.IsFailed)
			{
				string erro = resultado.Errors[0].Message;

				TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

				DialogResult = DialogResult.None;
			}
		}
	}
}
