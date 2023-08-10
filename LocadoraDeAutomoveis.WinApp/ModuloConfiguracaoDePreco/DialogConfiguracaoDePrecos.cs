using LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.WinApp.Compartilhado;

namespace LocadoraDeAutomoveis.WinApp.ModuloConfiguracaoDePreco
{
    public partial class DialogConfiguracaoDePrecos : Form
    {
        private ConfiguracaoDePrecos? configuracaoDePrecos;

        public event GravarRegistroDelegate<ConfiguracaoDePrecos>? onGravarRegistro;
        public DialogConfiguracaoDePrecos()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public ConfiguracaoDePrecos ConfiguracaoDePrecos
        {
            set
            {
                configuracaoDePrecos = value;

                txtGasolina.Text = Convert.ToString(configuracaoDePrecos.Gasolina);
                txtGas.Text = Convert.ToString(configuracaoDePrecos.Gas);
                txtDiesel.Text = Convert.ToString(configuracaoDePrecos.Diesel);
                txtAlcool.Text = Convert.ToString(configuracaoDePrecos.Alcool);



            }
            get
            {
                configuracaoDePrecos!.Gasolina = Convert.ToDecimal(txtGasolina.Value);
                configuracaoDePrecos.Gas = Convert.ToDecimal(txtGas.Value);
                configuracaoDePrecos.Diesel = Convert.ToDecimal(txtDiesel.Value);
                configuracaoDePrecos.Alcool = Convert.ToDecimal(txtAlcool.Value);

                return configuracaoDePrecos;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Result resultado = onGravarRegistro!(ConfiguracaoDePrecos);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
