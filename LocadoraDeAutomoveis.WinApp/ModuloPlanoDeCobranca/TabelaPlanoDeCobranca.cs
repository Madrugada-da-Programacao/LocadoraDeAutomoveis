using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.WinApp.ModuloPlanoDeCobranca
{
    public partial class TabelaPlanoDeCobranca : UserControl
    {
        public TabelaPlanoDeCobranca()
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

                new DataGridViewTextBoxColumn { Name = "GrupoDeAutomoveis", HeaderText = "Grupo de Automóveis"},

                new DataGridViewTextBoxColumn { Name = "TipoDoPlano", HeaderText = "Tipo do Plano"},

                new DataGridViewTextBoxColumn { Name = "PrecoDiaria", HeaderText = "Preço Diaria"},

                new DataGridViewTextBoxColumn { Name = "PrecoKm", HeaderText = "Preço por Km"},

                new DataGridViewTextBoxColumn { Name = "KmDisponiveis", HeaderText = "Km Disponíveis"},
            };

            return colunas;
        }

        public void AtualizarRegistros(List<PlanoDeCobranca> registros)
        {
            grid.Rows.Clear();

            registros.ForEach(r => grid.Rows.Add(r.Id
                                                , r.TipoDoPlano
                                                , r.PrecoDiaria
                                                , r.PrecoKm
                                                , r.KmDisponiveis));
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
