using LocadoraDeAutomoveis.Dominio.ModuloCupom;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloCupom
{
	public class RepositorioCupomEmOrm : RepositorioBaseEmOrm<Cupom>, IRepositorioCupom
	{
		public RepositorioCupomEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
		{
		}

		public Cupom? SelecionarPorNome(string nome)
		{
			return registros.FirstOrDefault(x => x.Nome == nome);
		}
	}
}
