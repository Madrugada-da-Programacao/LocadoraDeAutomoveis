using LocadoraDeAutomoveis.Aplicacao.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;

namespace LocadoraDeAutomoveis.WinApp.ModuloCliente
{
	public class ControladorCliente : ControladorBase
	{
		private IRepositorioCliente RepositorioCliente { get; set; }
		private ServicoCliente ServicoCliente { get; set; }
		private TabelaCliente? TabelaCliente { get; set; }

		public ControladorCliente(IRepositorioCliente repositorioCliente, ServicoCliente servicoCliente)
		{
			RepositorioCliente = repositorioCliente;
			ServicoCliente = servicoCliente;
		}

		public override void Inserir()
		{
			DialogCliente dialog = new DialogCliente();

			dialog.onGravarRegistro += ServicoCliente.Inserir;

			dialog.Cliente = new Cliente();

			DialogResult resultado = dialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				CarregarEntidades();
			}
		}

		public override void Editar()
		{
			Guid idRegistro = TabelaCliente!.ObtemIdSelecionado();
			Cliente? registro = RepositorioCliente.SelecionarPorId(idRegistro);

			if (registro == null)
			{
				MessageBox.Show($"Selecione um {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
								$"Edição de {ObtemConfiguracaoToolbox().TipoEntidade}s",
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);

				return;
			}

			DialogCliente dialog = new DialogCliente();

			dialog.onGravarRegistro += ServicoCliente.Editar;

			dialog.Cliente = registro;

			DialogResult resultado = dialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				CarregarEntidades();
			}
		}

		public override void Excluir()
		{
			Guid idRegistro = TabelaCliente!.ObtemIdSelecionado();
			Cliente? registro = RepositorioCliente.SelecionarPorId(idRegistro);

			if (registro == null)
			{
				MessageBox.Show($"Selecione um {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
								$"Exclusão de {ObtemConfiguracaoToolbox().TipoEntidade}s",
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);

				return;
			}

			DialogResult opcao = MessageBox.Show($"Deseja excluir o {ObtemConfiguracaoToolbox().TipoEntidade}?",
														  $"Exclusão de {ObtemConfiguracaoToolbox().TipoEntidade}s",
														  MessageBoxButtons.OKCancel,
														  MessageBoxIcon.Question);

			if (opcao == DialogResult.OK)
			{
				Result resultado = ServicoCliente.Excluir(registro);

				if (resultado.IsFailed)
				{
					MessageBox.Show(resultado.Errors[0].Message, $"Exclusão de {ObtemConfiguracaoToolbox().TipoEntidade}s",
						MessageBoxButtons.OK, MessageBoxIcon.Error);

					return;
				}

				CarregarEntidades();
			}
		}

		public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
		{
			return new ConfiguracaoToolboxCliente();
		}

		public override UserControl ObtemListagem()
		{
			TabelaCliente ??= new TabelaCliente();

			CarregarEntidades();

			return TabelaCliente;
		}

		private void CarregarEntidades()
		{
			List<Cliente> registros = RepositorioCliente.SelecionarTodos();

			TabelaCliente!.AtualizarRegistros(registros);

			mensagemRodape = string.Format("Visualizando {0} cliente{1}", registros.Count, registros.Count == 1 ? "" : "s");

			TelaPrincipalForm.Instancia!.AtualizarRodape(mensagemRodape);
		}
	}
}
