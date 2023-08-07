using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;

namespace LocadoraDeAutomoveis.WinApp.ModuloTaxaOuServico
{
	public class ControladorTaxaOuServico : ControladorBase
	{
		private IRepositorioTaxaOuServico RepositorioTaxaOuServico { get; set; }
		private ServicoTaxaOuServico ServicoTaxaOuServico { get; set; }
		private TabelaTaxaOuServico? TabelaTaxaOuServico { get; set; }

		public ControladorTaxaOuServico(IRepositorioTaxaOuServico repositorioTaxaOuServico, ServicoTaxaOuServico servicoTaxaOuServico)
		{
			RepositorioTaxaOuServico = repositorioTaxaOuServico;
			ServicoTaxaOuServico = servicoTaxaOuServico;
		}

		public override void Inserir()
		{
			DialogTaxaOuServico dialog = new DialogTaxaOuServico();

			dialog.onGravarRegistro += ServicoTaxaOuServico.Inserir;

			dialog.TaxaOuServico = new TaxaOuServico();

			DialogResult resultado = dialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				CarregarEntidades();
			}
		}

		public override void Editar()
		{
			Guid idRegistro = TabelaTaxaOuServico!.ObtemIdSelecionado();
			TaxaOuServico? registro = RepositorioTaxaOuServico.SelecionarPorId(idRegistro);

			if (registro == null)
			{
				MessageBox.Show($"Selecione uma {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
								$"Edição de {ObtemConfiguracaoToolbox().TipoEntidade}s",
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);

				return;
			}

			DialogTaxaOuServico dialog = new DialogTaxaOuServico();

			dialog.onGravarRegistro += ServicoTaxaOuServico.Editar;

			dialog.TaxaOuServico = registro;

			DialogResult resultado = dialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				CarregarEntidades();
			}
		}

		public override void Excluir()
		{
			Guid idRegistro = TabelaTaxaOuServico!.ObtemIdSelecionado();
			TaxaOuServico? registro = RepositorioTaxaOuServico.SelecionarPorId(idRegistro);

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
				Result resultado = ServicoTaxaOuServico.Excluir(registro);

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
			return new ConfiguracaoToolboxTaxaOuServico();
		}

		public override UserControl ObtemListagem()
		{
			TabelaTaxaOuServico ??= new TabelaTaxaOuServico();

			CarregarEntidades();

			return TabelaTaxaOuServico;
		}

		private void CarregarEntidades()
		{
			List<TaxaOuServico> registros = RepositorioTaxaOuServico.SelecionarTodos();

			TabelaTaxaOuServico!.AtualizarRegistros(registros);

			mensagemRodape = string.Format("Visualizando {0} taxa{1} ou serviço{1}", registros.Count, registros.Count == 1 ? "" : "s");

			TelaPrincipalForm.Instancia!.AtualizarRodape(mensagemRodape);
		}
	}
}
