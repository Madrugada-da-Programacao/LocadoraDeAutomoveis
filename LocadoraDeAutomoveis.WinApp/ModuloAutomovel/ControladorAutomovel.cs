using LocadoraDeAutomoveis.Aplicacao.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;

namespace LocadoraDeAutomoveis.WinApp.ModuloAutomovel
{
	public class ControladorAutomovel : ControladorBase
	{
		private IRepositorioAutomovel RepositorioAutomovel { get; set; }
		private IRepositorioGrupoDeAutomoveis RepositorioGrupoDeAutomoveis { get; set; }
		private ServicoAutomovel ServicoAutomovel { get; set; }
		private TabelaAutomovel? TabelaAutomovel { get; set; }

		public ControladorAutomovel(IRepositorioAutomovel repositorioAutomovel, ServicoAutomovel servicoAutomovel, IRepositorioGrupoDeAutomoveis repositorioGrupoDeAutomoveis)
		{
			RepositorioAutomovel = repositorioAutomovel;
			ServicoAutomovel = servicoAutomovel;
			RepositorioGrupoDeAutomoveis = repositorioGrupoDeAutomoveis;
		}

		public override void Inserir()
		{
			List<GrupoDeAutomoveis> grupo = SelecionarGruposDeAutomoveis();
			DialogAutomovel dialog = new DialogAutomovel(grupo);

			dialog.onGravarRegistro += ServicoAutomovel!.Inserir;

			dialog.Automovel = new Automovel();

			DialogResult resultado = dialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				CarregarEntidades();
			}
		}

		public override void Editar()
		{
			Guid idRegistro = TabelaAutomovel!.ObtemIdSelecionado();
			Automovel? registro = RepositorioAutomovel.SelecionarPorId(idRegistro);

			if (registro == null)
			{
				MessageBox.Show($"Selecione uma {ObtemConfiguracaoToolbox().TipoEntidade} primeiro!",
								$"Edição de {ObtemConfiguracaoToolbox().TipoEntidade}s",
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);

				return;
			}
            List<GrupoDeAutomoveis> grupo = SelecionarGruposDeAutomoveis();
            DialogAutomovel dialog = new DialogAutomovel(grupo);

			dialog.onGravarRegistro += ServicoAutomovel!.Editar;

			dialog.Automovel = registro;

			DialogResult resultado = dialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				CarregarEntidades();
			}
		}

		public override void Excluir()
		{
			Guid idRegistro = TabelaAutomovel!.ObtemIdSelecionado();
			Automovel? registro = RepositorioAutomovel!.SelecionarPorId(idRegistro);

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
				Result resultado = ServicoAutomovel!.Excluir(registro);

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
			return new ConfiguracaoToolboxAutomovel();
		}

		public override UserControl ObtemListagem()
		{
			TabelaAutomovel ??= new TabelaAutomovel();

			CarregarEntidades();

			return TabelaAutomovel;
		}

		private void CarregarEntidades()
		{
			//List<Automovel> registros = RepositorioAutomovel.SelecionarTodos();
			List<Automovel> registros = RepositorioAutomovel.SelecionarTodosComGrupoDeAutomovel();

			TabelaAutomovel!.AtualizarRegistros(registros);

			mensagemRodape = string.Format("Visualizando {0} automovel{1}", registros.Count, registros.Count == 1 ? "" : "s");

			TelaPrincipalForm.Instancia!.AtualizarRodape(mensagemRodape);
		}
        private List<GrupoDeAutomoveis> SelecionarGruposDeAutomoveis()
        {
            List<GrupoDeAutomoveis> grupo = new List<GrupoDeAutomoveis>();

            grupo = RepositorioGrupoDeAutomoveis.SelecionarTodos();

            return grupo;
        }
    }
}
