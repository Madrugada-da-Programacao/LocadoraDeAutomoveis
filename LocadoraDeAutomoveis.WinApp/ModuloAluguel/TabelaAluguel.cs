using LocadoraDeAutomoveis.Dominio.ModuloAluguel;

namespace LocadoraDeAutomoveis.WinApp.ModuloAluguel
{
    public partial class TabelaAluguel : UserControl
    {
        public TabelaAluguel()
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

                new DataGridViewTextBoxColumn { Name = "NomeDoCondutor", HeaderText = "Nome do Condutor"},

                new DataGridViewTextBoxColumn { Name = "Veiculo", HeaderText = "Veículo"},

                new DataGridViewTextBoxColumn { Name = "PlanoSelecionado", HeaderText = "Plano Selecionado"},

                new DataGridViewTextBoxColumn { Name = "DataDeLocação", HeaderText = "Data de Locação"},

                new DataGridViewTextBoxColumn { Name = "DataDeDevolucaoPrevista", HeaderText = "Data de Devolução Prevista"},

                new DataGridViewTextBoxColumn { Name = "DataDeDevolucao", HeaderText = "Data de Devolução"},

                new DataGridViewTextBoxColumn { Name = "ValorTotal", HeaderText = "ValorTotal"},
            };

            return colunas;
        }

        public void AtualizarRegistros(List<Aluguel> registros)
        {
            grid.Rows.Clear();

            registros.ForEach(r => grid.Rows.Add(r.Id
                                                , r.Condutor.Nome
                                                , r.Automovel.Placa
                                                , r.PlanoDeCobranca.GrupoDeAutomoveis.Nome
                                                , r.DataLocacao.ToShortDateString()
                                                , r.DataDevolucaoPrevista.ToShortDateString()
                                                , r.DataDevolucao.ToShortDateString()
                                                , r.ValorTotal));
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
