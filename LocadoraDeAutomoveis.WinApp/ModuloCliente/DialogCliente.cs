using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.WinApp.Compartilhado;

namespace LocadoraDeAutomoveis.WinApp.ModuloCliente
{
	public partial class DialogCliente : Form
	{
		private Cliente? cliente;

		public event GravarRegistroDelegate<Cliente>? onGravarRegistro;
		public DialogCliente()
		{
			InitializeComponent();
			this.ConfigurarDialog();
		}

		public Cliente Cliente
		{
			set
			{
				cliente = value;
				txtNome.Text = cliente.Nome;
				txtEmail.Text = cliente.Email;
				maskedtxtTelefone.Text = cliente.Telefone;

				if (cliente.TipoCliente == Cliente.TipoDeCliente.PessoaFisica)
				{
					radioButtonPessoaFisica.Checked = true;
					maskedtxtCPF.Text = cliente.NumeroDoDocumento;
				}
				else
				{
					radioButtonPessoaJuridica.Checked = true;
					maskedtxtCNPJ.Text = cliente.NumeroDoDocumento;
				}

				txtEstado.Text = cliente.Estado;
				txtCidade.Text = cliente.Cidade;
				txtBairro.Text = cliente.Bairro;
				txtRua.Text = cliente.Rua;
				numericUpDownNumero.Value = cliente.Numero;
			}
			get
			{
				cliente!.Nome = txtNome.Text;
				cliente.Email = txtEmail.Text;
				cliente.Telefone = maskedtxtTelefone.Text;

				if (radioButtonPessoaFisica.Checked == true)
				{
					cliente.TipoCliente = Cliente.TipoDeCliente.PessoaFisica;
					cliente.NumeroDoDocumento = maskedtxtCPF.Text;
				}
				else
				{
					cliente.TipoCliente = Cliente.TipoDeCliente.PessoaJuridica;
					cliente.NumeroDoDocumento = maskedtxtCNPJ.Text;
				}

				cliente.Estado = txtEstado.Text;
				cliente.Cidade = txtCidade.Text;
				cliente.Bairro = txtBairro.Text;
				cliente.Rua = txtRua.Text;
				cliente.Numero = (int)numericUpDownNumero.Value;

				return cliente;
			}
		}

		private void btnGravar_Click(object sender, EventArgs e)
		{
			Result resultado = onGravarRegistro!(Cliente);

			if (resultado.IsFailed)
			{
				string erro = resultado.Errors[0].Message;

				TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

				DialogResult = DialogResult.None;
			}
		}

		private void radioButtonTipoDePessoa_CheckedChanged(object sender, EventArgs e)
		{
			maskedtxtCPF.Enabled = radioButtonPessoaFisica.Checked;
			if (!maskedtxtCPF.Enabled)
			{
				maskedtxtCPF.Clear();
			}

			maskedtxtCNPJ.Enabled = radioButtonPessoaJuridica.Checked;
			if (!maskedtxtCNPJ.Enabled)
			{
				maskedtxtCNPJ.Clear();
			}
		}
	}
}
