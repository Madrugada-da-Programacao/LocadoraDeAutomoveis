using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.WinApp.Compartilhado;
using static LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca.PlanoDeCobranca;

namespace LocadoraDeAutomoveis.WinApp.ModuloPlanoDeCobranca
{
    public partial class DialogPlanoDeCobranca : Form
    {
        private PlanoDeCobranca? planoDeCobranca;

        public List<GrupoDeAutomoveis> grupoDeAutomoveis { get; set; }

        public event GravarRegistroDelegate<PlanoDeCobranca>? onGravarRegistro;
        public DialogPlanoDeCobranca()
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarGrupoDeAutomoveis();

            cmbGrupoAutomoveis.DisplayMember = "Nome";
        }

        private void CarregarGrupoDeAutomoveis()
        {
            foreach (GrupoDeAutomoveis g in grupoDeAutomoveis)
            {
                cmbGrupoAutomoveis.Items.Add(g);
            }
        }

        public PlanoDeCobranca PlanoDeCobranca
        {
            set
            {
                planoDeCobranca = value;

                txtPrecoDiariaPlanoDiaria.Value = planoDeCobranca.PrecoDiariaPlanoDiario;
                txtPrecoKmPlanoDiaria.Value = planoDeCobranca.PrecoKmPlanoDiario;
                txtPrecoDiariaKmControlado.Value = planoDeCobranca.PrecoDiariaKmControlado;
                txtPrecoKmKmControlado.Value = planoDeCobranca.PrecoKmExtrapoladoKmControlado;
                txtKmDisponiveisKmControlado.Value = planoDeCobranca.KmDisponiveisKmControlado;
                txtPrecoDiariaKmLivre.Value = planoDeCobranca.PrecoDiariaKmLivre;
            }
            get
            {
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
