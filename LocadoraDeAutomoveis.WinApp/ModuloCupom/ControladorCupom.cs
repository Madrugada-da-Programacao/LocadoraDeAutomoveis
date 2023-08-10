using LocadoraDeAutomoveis.Aplicacao.ModuloCliente;
using LocadoraDeAutomoveis.Aplicacao.ModuloCupom;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCupom;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloParceiro;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.WinApp.ModuloCliente;
using LocadoraDeAutomoveis.WinApp.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.WinApp.ModuloCupom
{
	public class ControladorCupom : ControladorBase
	{
		private IRepositorioCupom RepositorioCupom { get; set; }
		private IRepositorioParceiro RepositorioParceiro { get; set; }
		private ServicoCupom ServicoCupom { get; set; }
		private TabelaCupom? TabelaCupom { get; set; }

		public ControladorCupom(IRepositorioCupom repositorioCupom, IRepositorioParceiro repositorioParceiro, ServicoCupom servicoCupom)
		{
			RepositorioCupom = repositorioCupom;
			RepositorioParceiro = repositorioParceiro;
			ServicoCupom = servicoCupom;
		}

		public override void Inserir()
		{
			DialogCupom dialog = new DialogCupom(RepositorioParceiro.SelecionarTodos());

			dialog.onGravarRegistro += ServicoCupom.Inserir;

			dialog.Cupom = new Cupom();
			DialogResult resultado = dialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				CarregarEntidades();
			}
		}

		public override void Editar()
		{
			Guid idRegistro = TabelaCupom!.ObtemIdSelecionado();
			Cupom? registro = RepositorioCupom.SelecionarPorId(idRegistro);

			if (registro == null)
			{
				MessageBox.Show($"Selecione uma {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
								$"Edição de {ObtemConfiguracaoToolbox().TipoEntidade}s",
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);

				return;
			}

			DialogCupom dialog = new DialogCupom(RepositorioParceiro.SelecionarTodos());

			dialog.onGravarRegistro += ServicoCupom.Editar;

			dialog.Cupom = registro;

			DialogResult resultado = dialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				CarregarEntidades();
			}
		}

		public override void Excluir()
		{
			Guid idRegistro = TabelaCupom!.ObtemIdSelecionado();
			Cupom? registro = RepositorioCupom.SelecionarPorId(idRegistro);

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
				Result resultado = ServicoCupom.Excluir(registro);

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
			return new ConfiguracaoToolboxCupom();
		}

		public override UserControl ObtemListagem()
		{
			TabelaCupom ??= new TabelaCupom();

			CarregarEntidades();

			return TabelaCupom;
		}

		private void CarregarEntidades()
		{
			List<Cupom> registros = RepositorioCupom.SelecionarTodos();

			TabelaCupom!.AtualizarRegistros(registros);

			mensagemRodape = string.Format("Visualizando {0} cupom{1}", registros.Count, registros.Count == 1 ? "" : "s");

			TelaPrincipalForm.Instancia!.AtualizarRodape(mensagemRodape);
		}
	}
}
