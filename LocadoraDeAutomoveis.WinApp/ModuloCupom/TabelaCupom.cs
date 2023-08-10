using LocadoraDeAutomoveis.Dominio.ModuloCupom;

namespace LocadoraDeAutomoveis.WinApp.ModuloCupom
{
	public partial class TabelaCupom : UserControl
	{
		public TabelaCupom()
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

				new DataGridViewTextBoxColumn { Name = "Preco", HeaderText = "Preço"},

				new DataGridViewTextBoxColumn { Name = "DataValidade", HeaderText = "Data de Validade"},

				new DataGridViewTextBoxColumn { Name = "Parceiro", HeaderText = "Parceiro"},
			};

			return colunas;
		}

		public void AtualizarRegistros(List<Cupom> registros)
		{
			grid.Rows.Clear();

			registros.ForEach(r => grid.Rows.Add(r.Id
												, r.Nome
												, r.Preco
												, r.DataValidade.ToShortDateString()
												, r.Parceiro!.Nome));
		}

		public Guid ObtemIdSelecionado()
		{
			return grid.SelecionarId();
		}
	}
}
