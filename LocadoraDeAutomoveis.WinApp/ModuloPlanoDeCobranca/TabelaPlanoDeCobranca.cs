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

                new DataGridViewTextBoxColumn { Name = "PrecoDiariaPlanoDiario", HeaderText = "Preço Diaria Plano Diario"},

                new DataGridViewTextBoxColumn { Name = "PrecoKmPlanoDiario", HeaderText = "Preço por Km Plano Diario"},

                new DataGridViewTextBoxColumn { Name = "PrecoDiariaKmControlado", HeaderText = "Preço Diaria Plano Km Controlado"},

                new DataGridViewTextBoxColumn { Name = "PrecoKmExtrapoladoKmControlado", HeaderText = "Preço por Km Extrapolado Plano Km Controlado"},

                new DataGridViewTextBoxColumn { Name = "KmDisponiveisKmControlado", HeaderText = "Km Disponíveis Plano Km Controlado"},

                new DataGridViewTextBoxColumn { Name = "PrecoDiariaKmLivre", HeaderText = "Preço Diaria Plano Km Livre"}
            };

            return colunas;
        }

        public void AtualizarRegistros(List<PlanoDeCobranca> registros)
        {
            grid.Rows.Clear();

            registros.ForEach(r => grid.Rows.Add(r.Id
                                                , r.GrupoDeAutomoveis.Nome
                                                , r.PrecoDiariaPlanoDiario
                                                , r.PrecoKmPlanoDiario
                                                , r.PrecoDiariaKmControlado
                                                , r.PrecoKmExtrapoladoKmControlado
                                                , r.KmDisponiveisKmControlado
                                                , r.PrecoDiariaKmLivre));
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
