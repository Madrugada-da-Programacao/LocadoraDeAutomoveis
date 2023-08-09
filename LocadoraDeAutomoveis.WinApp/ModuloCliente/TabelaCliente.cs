using LocadoraDeAutomoveis.Dominio.ModuloCliente;

namespace LocadoraDeAutomoveis.WinApp.ModuloCliente
{
	public partial class TabelaCliente : UserControl
	{
		public TabelaCliente()
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

				new DataGridViewTextBoxColumn { Name = "TipoCliente", HeaderText = "Tipo de Cliente"},

				new DataGridViewTextBoxColumn { Name = "NumeroDoDocumento", HeaderText = "Numero do Documento"},

				new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email"},

				new DataGridViewTextBoxColumn { Name = "Telefone", HeaderText = "Telefone"},

				new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado"},

				new DataGridViewTextBoxColumn { Name = "Cidade", HeaderText = "Cidade"},

				new DataGridViewTextBoxColumn { Name = "Bairro", HeaderText = "Bairro"},

				new DataGridViewTextBoxColumn { Name = "Rua", HeaderText = "Rua"},

				new DataGridViewTextBoxColumn { Name = "Numero", HeaderText = "Numero"},
			};

			return colunas;
		}

		public void AtualizarRegistros(List<Cliente> registros)
		{
			grid.Rows.Clear();

			registros.ForEach(r => grid.Rows.Add(r.Id
												,r.Nome
												,r.TipoCliente.GetDescription()
												,r.NumeroDoDocumento
												,r.Email
												,r.Telefone
												,r.Estado
												,r.Cidade
												,r.Bairro
												,r.Rua
												,r.Numero));
		}

		public Guid ObtemIdSelecionado()
		{
			return grid.SelecionarId();
		}
	}
}
