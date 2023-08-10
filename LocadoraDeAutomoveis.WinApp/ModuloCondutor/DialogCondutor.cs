using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraDeAutomoveis.WinApp.ModuloCondutor
{
    public partial class DialogCondutor : Form
    {
        private Condutor? condutor;

        public event GravarRegistroDelegate<Condutor>? onGravarRegistro;
        public DialogCondutor(List<Cliente> clientes)
        {
            InitializeComponent();
            this.ConfigurarDialog();

            cmbCliente.DisplayMember = "Nome";
            cmbCliente.DataSource = clientes;

            //ConfigurarClientes(clientes);
        }

        private void ConfigurarClientes(List<Cliente> clientes)
        {
            foreach (Cliente c in clientes)
            {
                cmbCliente.Items.Add(c);
            }
        }

        public Condutor Condutor
        {
            set
            {
                condutor = value;
                if (condutor.Cliente != null)
                    cmbCliente.SelectedItem = condutor.Cliente;

                txtNome.Text = condutor.Nome;
                cbClienteEhCondutor.Checked = condutor.ClienteEhCondutor;
                txtEmail.Text = condutor.Email;
                txtTelefone.Text = condutor.Telefone;
                txtCpf.Text = condutor.Cpf;
                txtCnh.Value = Convert.ToDecimal(condutor.Cnh);
                txtValidade.Value = condutor.Validade;
            }
            get
            {
                condutor.Cliente = (Cliente)cmbCliente.SelectedItem;
                condutor.Nome = txtNome.Text;
                condutor.ClienteEhCondutor = cbClienteEhCondutor.Checked;
                condutor.Email = txtEmail.Text;
                condutor.Telefone = txtTelefone.Text;
                condutor.Cpf = txtCpf.Text;
                condutor.Cnh = Convert.ToString(txtCnh.Value);
                condutor.Validade = txtValidade.Value;

                return condutor;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Result resultado = onGravarRegistro!(Condutor);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void cbClienteEhCondutor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbClienteEhCondutor.Checked == true)
            {
                if (cmbCliente.SelectedItem == null)
                {
                    string erro = "Escolha um cliente antes de marcar que o cliente é o condutor!";

                    TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

                    cbClienteEhCondutor.Checked = false;

                    return;
                }

                Cliente clienteEscolhido = (Cliente)cmbCliente.SelectedItem;

                txtNome.Text = clienteEscolhido.Nome;
                txtEmail.Text = clienteEscolhido.Email;
                txtTelefone.Text = clienteEscolhido.Telefone;

                txtNome.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtTelefone.ReadOnly = true;


                txtCpf.Text = clienteEscolhido.NumeroDoDocumento;
                txtCpf.ReadOnly = true;

            }

            if (cbClienteEhCondutor.Checked == false)
            {
                txtNome.Text = "";
                txtEmail.Text = "";
                txtTelefone.Text = "";

                txtNome.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtTelefone.ReadOnly = false;

                txtCpf.Text = "";
                txtCpf.ReadOnly = false;

            }
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente clienteSelecionado = (Cliente)cmbCliente.SelectedItem;

            if (clienteSelecionado.TipoCliente == Cliente.TipoDeCliente.PessoaFisica)
            {
                cbClienteEhCondutor.Enabled = true;
            }
            else
            {
                cbClienteEhCondutor.Enabled = false;
                cbClienteEhCondutor.Checked = false;

                txtNome.Text = "";
                txtEmail.Text = "";
                txtTelefone.Text = "";

                txtNome.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtTelefone.ReadOnly = false;

                txtCpf.Text = "";
                txtCpf.ReadOnly = false;
            }

        }
    }
}
