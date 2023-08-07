using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.WinApp.Compartilhado;
using static LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca.PlanoDeCobranca;

namespace LocadoraDeAutomoveis.WinApp.ModuloPlanoDeCobranca
{
    public partial class DialogPlanoDeCobranca : Form
    {
        private PlanoDeCobranca? planoDeCobranca;

        public event GravarRegistroDelegate<PlanoDeCobranca>? onGravarRegistro;
        public DialogPlanoDeCobranca()
        {
            InitializeComponent();
            this.ConfigurarDialog();
            //CarregarGrupoDeAutomoveis();TODO
            CarregarTiposDePlano();
        }

        public PlanoDeCobranca PlanoDeCobranca
        {
            set
            {
                planoDeCobranca = value;
                cmbTipoDoPlano.SelectedItem = planoDeCobranca.TipoDoPlano;
                txtPrecoDiaria.Value = planoDeCobranca.PrecoDiaria;
                txtPrecoKm.Value = planoDeCobranca.PrecoKm;
                txtKmDisponiveis.Value = planoDeCobranca.KmDisponiveis;
            }
            get
            {
                planoDeCobranca!.TipoDoPlano = (TipoDoPlanoEnum)cmbTipoDoPlano.SelectedItem;
                planoDeCobranca.PrecoDiaria = txtPrecoDiaria.Value;
                planoDeCobranca.PrecoKm = txtPrecoKm.Value;
                planoDeCobranca.KmDisponiveis = Convert.ToInt32(txtKmDisponiveis.Value);

                return planoDeCobranca;
            }
        }

        private void CarregarTiposDePlano()
        {
            TipoDoPlanoEnum[] TiposDePlano = Enum.GetValues<TipoDoPlanoEnum>();

            foreach (TipoDoPlanoEnum t in TiposDePlano)
            {
                cmbTipoDoPlano.Items.Add(t);
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
