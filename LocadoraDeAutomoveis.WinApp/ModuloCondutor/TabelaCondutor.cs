using LocadoraDeAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraDeAutomoveis.WinApp.ModuloCondutor
{
    public partial class TabelaCondutor : UserControl
    {
        public TabelaCondutor()
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

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome do Condutor"},

                new DataGridViewTextBoxColumn { Name = "NomeDoCliente", HeaderText = "Nome do Cliente"},

                new DataGridViewTextBoxColumn { Name = "CPF", HeaderText = "CPF"},

                new DataGridViewTextBoxColumn { Name = "CNH", HeaderText = "CNH"},

                new DataGridViewTextBoxColumn { Name = "Validade", HeaderText = "Validade"}
            };

            return colunas;
        }

        public void AtualizarRegistros(List<Condutor> registros)
        {
            grid.Rows.Clear();

            registros.ForEach(r => grid.Rows.Add(r.Id
                                                , r.Nome
                                                , r.Cliente.Nome
                                                , r.Cpf
                                                , r.Cnh
                                                , r.Validade.ToShortDateString()));
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
