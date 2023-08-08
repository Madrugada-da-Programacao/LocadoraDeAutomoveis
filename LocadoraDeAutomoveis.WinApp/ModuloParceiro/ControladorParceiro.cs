using LocadoraDeAutomoveis.Aplicacao.ModuloCliente;
using LocadoraDeAutomoveis.Aplicacao.ModuloParceiro;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloParceiro;
using LocadoraDeAutomoveis.WinApp.ModuloCliente;

namespace LocadoraDeAutomoveis.WinApp.ModuloParceiro
{
	public class ControladorParceiro : ControladorBase
	{
		private IRepositorioParceiro RepositorioParceiro { get; set; }
		private ServicoParceiro ServicoParceiro { get; set; }
		private TabelaParceiro? TabelaParceiro { get; set; }

		public ControladorParceiro(IRepositorioParceiro repositorioParceiro, ServicoParceiro servicoParceiro)
		{
			RepositorioParceiro = repositorioParceiro;
			ServicoParceiro = servicoParceiro;
		}

		public override void Inserir()
		{
			DialogParceiro dialog = new DialogParceiro();

			dialog.onGravarRegistro += ServicoParceiro.Inserir;

			dialog.Parceiro = new Parceiro();

			DialogResult resultado = dialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				CarregarEntidades();
			}
		}

		public override void Editar()
		{
			Guid idRegistro = TabelaParceiro!.ObtemIdSelecionado();
			Parceiro? registro = RepositorioParceiro.SelecionarPorId(idRegistro);

			if (registro == null)
			{
				MessageBox.Show($"Selecione uma {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
								$"Edição de {ObtemConfiguracaoToolbox().TipoEntidade}s",
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);

				return;
			}

			DialogParceiro dialog = new DialogParceiro();

			dialog.onGravarRegistro += ServicoParceiro.Editar;

			dialog.Parceiro = registro;

			DialogResult resultado = dialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				CarregarEntidades();
			}
		}

		public override void Excluir()
		{
			Guid idRegistro = TabelaParceiro!.ObtemIdSelecionado();
			Parceiro? registro = RepositorioParceiro.SelecionarPorId(idRegistro);

			if (registro == null)
			{
				MessageBox.Show($"Selecione um {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
								$"Exclusão de {ObtemConfiguracaoToolbox().TipoEntidade}s",
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);

				return;
			}

			DialogResult opcao = MessageBox.Show($"Deseja excluir a {ObtemConfiguracaoToolbox().TipoEntidade}?",
														  $"Exclusão de {ObtemConfiguracaoToolbox().TipoEntidade}s",
														  MessageBoxButtons.OKCancel,
														  MessageBoxIcon.Question);

			if (opcao == DialogResult.OK)
			{
				Result resultado = ServicoParceiro.Excluir(registro);

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
			return new ConfiguracaoToolboxParceiro();
		}

		public override UserControl ObtemListagem()
		{
			TabelaParceiro ??= new TabelaParceiro();

			CarregarEntidades();

			return TabelaParceiro;
		}

		private void CarregarEntidades()
		{
			List<Parceiro> registros = RepositorioParceiro.SelecionarTodos();

			TabelaParceiro!.AtualizarRegistros(registros);

			mensagemRodape = string.Format("Visualizando {0} cliente{1}", registros.Count, registros.Count == 1 ? "" : "s");

			TelaPrincipalForm.Instancia!.AtualizarRodape(mensagemRodape);
		}
	}
}
