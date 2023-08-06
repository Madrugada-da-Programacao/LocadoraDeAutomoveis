using LocadoraDeAutomoveis.Dominio;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.WinApp.ModuloFuncionario;

namespace LocadoraDeAutomoveis.WinApp.ModuloFuncionario
{
    public partial class TabelaFuncionario : UserControl
    {
        public TabelaFuncionario()
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

                new DataGridViewTextBoxColumn { Name = "DataAdmissao", HeaderText = "Data de Admissão"},

                new DataGridViewTextBoxColumn { Name = "Salario", HeaderText = "Salário"},
            };

            return colunas;
        }

        public void AtualizarRegistros(List<Funcionario> registros)
        {
            grid.Rows.Clear();

            registros.ForEach(r => grid.Rows.Add(r.Id
                                                , r.Nome
                                                , r.DataAdmissao.ToShortDateString()
                                                , r.Salario));
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }

    }
}
