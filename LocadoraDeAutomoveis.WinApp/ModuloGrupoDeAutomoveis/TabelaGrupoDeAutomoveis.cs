using LocadoraDeAutomoveis.Dominio;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace LocadoraDeAutomoveis.WinApp.ModuloGrupoDeAutomoveis
{
	public partial class TabelaGrupoDeAutomoveis : UserControl
	{
		public TabelaGrupoDeAutomoveis()
		{
			InitializeComponent();

			grid.ConfigurarGridZebrado();
			grid.ConfigurarGridSomenteLeitura();
			grid.Columns.AddRange(ObterColunas());
		}

		public DataGridViewColumn[] ObterColunas()
		{
			var colunas = new DataGridViewColumn[]
			{
				new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id"},

				new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome"}
			};

			return colunas;
		}

		public void AtualizarRegistros(List<GrupoDeAutomoveis> registros)
		{
			grid.Rows.Clear();

			registros.ForEach(r => grid.Rows.Add(r.Id ,r.Nome));
		}

		public Guid ObtemIdSelecionado()
		{
			return grid.SelecionarId();
		}
	}
}
