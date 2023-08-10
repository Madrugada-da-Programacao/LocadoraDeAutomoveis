using LocadoraDeAutomoveis.Dominio;
using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;

namespace LocadoraDeAutomoveis.WinApp.ModuloAutomovel
{
	public partial class TabelaAutomovel : UserControl
	{
		public TabelaAutomovel()
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

				new DataGridViewTextBoxColumn { Name = "Placa", HeaderText = "Placa"},

				new DataGridViewTextBoxColumn { Name = "Marca", HeaderText = "Marca"},

				new DataGridViewTextBoxColumn { Name = "Modelo", HeaderText = "Modelo"},

				new DataGridViewTextBoxColumn { Name = "Cor", HeaderText = "Cor"},

				new DataGridViewTextBoxColumn { Name = "TipoCombustivel", HeaderText = "Tipo de Combustivel"},

				new DataGridViewTextBoxColumn { Name = "CapacidadeCombustivel", HeaderText = "CapacidadeCombustivel"},

				new DataGridViewTextBoxColumn { Name = "Ano", HeaderText = "Ano"},

				new DataGridViewTextBoxColumn { Name = "KM", HeaderText = "KM"},

				new DataGridViewTextBoxColumn { Name = "GrupoDeAutomovel.Nome", HeaderText = "Grupo de Automovel"},
			};

			return colunas;
		}

		public void AtualizarRegistros(List<Automovel> registros)
		{
			grid.Rows.Clear();

			registros.ForEach(r => grid.Rows.Add(r.Id
												, r.Placa
												, r.Marca
												, r.Modelo
												, r.Cor
												, r.TipoCombustivel.GetDescription()
												, r.CapacidadeCombustivel
												, r.Ano
												, r.KM
												, r.GrupoDeAutomovel.Nome));
		}

		public Guid ObtemIdSelecionado()
		{
			return grid.SelecionarId();
		}
	}
}
