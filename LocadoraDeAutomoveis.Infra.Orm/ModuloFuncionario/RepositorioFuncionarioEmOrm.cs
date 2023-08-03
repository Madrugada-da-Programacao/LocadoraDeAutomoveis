using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioEmOrm : RepositorioBaseEmOrm<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionarioEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
        {
        }
    }
}
