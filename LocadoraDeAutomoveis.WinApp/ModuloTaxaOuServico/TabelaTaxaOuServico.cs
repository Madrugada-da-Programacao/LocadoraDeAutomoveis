using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;

namespace LocadoraDeAutomoveis.WinApp.ModuloTaxaOuServico
{
	public partial class TabelaTaxaOuServico : UserControl
	{
		public TabelaTaxaOuServico()
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

				new DataGridViewTextBoxColumn { Name = "TipoCliente", HeaderText = "Tipo de Cliente"},
			};

			return colunas;
		}

		public void AtualizarRegistros(List<TaxaOuServico> registros)
		{
			grid.Rows.Clear();

			registros.ForEach(r => grid.Rows.Add(r.Id
												,r.Nome
												,r.Preco
												,r.TipoCobranca.GetDescription()));
		}

		public Guid ObtemIdSelecionado()
		{
			return grid.SelecionarId();
		}
	}
}
