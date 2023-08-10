using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.WinApp.Compartilhado;

namespace LocadoraDeAutomoveis.WinApp.ModuloFuncionario
{
    public partial class DialogFuncionario : Form
    {
        private Funcionario? funcionario;

        public event GravarRegistroDelegate<Funcionario>? onGravarRegistro;
        public DialogFuncionario()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public Funcionario Funcionario
        {
            set
            {
                funcionario = value;
                txtNome.Text = funcionario.Nome;
                txtAdmissao.Value = funcionario.DataAdmissao;
                txtSalario.Value = funcionario.Salario;
            }
            get
            {
				funcionario!.Nome = txtNome.Text;
				funcionario.DataAdmissao = txtAdmissao.Value;
				funcionario.Salario = (int)txtSalario.Value;

				return funcionario;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Result resultado = onGravarRegistro!(Funcionario);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
