using LocadoraDeAutomoveis.Dominio;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.WinApp.Compartilhado;

namespace LocadoraDeAutomoveis.WinApp.ModuloGrupoDeAutomoveis
{
    public partial class DialogGrupoDeAutomoveis : Form
    {
        private GrupoDeAutomoveis grupoDeAutomoveis;

        public event GravarRegistroDelegate<GrupoDeAutomoveis> onGravarRegistro;
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
                labelId.Text = grupoDeAutomoveis.Id.ToString();
                txtNome.Text = grupoDeAutomoveis.Nome;
            }
            get
            {
                return grupoDeAutomoveis;
            }
        }

        public GrupoDeAutomoveis ObterGrupoDeAutomoveis()
        {
            grupoDeAutomoveis.Id = Guid.Parse(labelId.Text);
            grupoDeAutomoveis.Nome = txtNome.Text;

            return grupoDeAutomoveis;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Result resultado = onGravarRegistro(ObterGrupoDeAutomoveis());

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
