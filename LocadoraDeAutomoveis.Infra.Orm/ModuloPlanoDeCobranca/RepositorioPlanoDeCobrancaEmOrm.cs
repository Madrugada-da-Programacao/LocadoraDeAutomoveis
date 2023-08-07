using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloPlanoDeCobranca
{
    public class RepositorioPlanoDeCobrancaEmOrm : RepositorioBaseEmOrm<PlanoDeCobranca>, IRepositorioPlanoDeCobranca
    {
        public RepositorioPlanoDeCobrancaEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

    }
}
