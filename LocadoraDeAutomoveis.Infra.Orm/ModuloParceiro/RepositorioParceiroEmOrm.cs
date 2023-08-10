using LocadoraDeAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloParceiro
{
	public class RepositorioParceiroEmOrm : RepositorioBaseEmOrm<Parceiro>, IRepositorioParceiro
	{
		public RepositorioParceiroEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
		{
		}

		public Parceiro? SelecionarPorNome(string nome)
		{
			return registros.FirstOrDefault(x => x.Nome == nome);
		}
	}
}
