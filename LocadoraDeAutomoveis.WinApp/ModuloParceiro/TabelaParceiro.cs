using LocadoraDeAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraDeAutomoveis.WinApp.ModuloParceiro
{
	public partial class TabelaParceiro : UserControl
	{
		public TabelaParceiro()
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

				new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome"},
			};

			return colunas;
		}

		public void AtualizarRegistros(List<Parceiro> registros)
		{
			grid.Rows.Clear();

			registros.ForEach(r => grid.Rows.Add(r.Id
												, r.Nome));
		}

		public Guid ObtemIdSelecionado()
		{
			return grid.SelecionarId();
		}
	}
}
