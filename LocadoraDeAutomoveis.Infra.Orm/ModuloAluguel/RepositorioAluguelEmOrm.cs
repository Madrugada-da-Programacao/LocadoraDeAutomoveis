using LocadoraDeAutomoveis.Dominio.ModuloAluguel;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloAluguel
{
	public class RepositorioAluguelEmOrm : RepositorioBaseEmOrm<Aluguel>, IRepositorioAluguel
	{
		public RepositorioAluguelEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
		{
		}
	}
}
