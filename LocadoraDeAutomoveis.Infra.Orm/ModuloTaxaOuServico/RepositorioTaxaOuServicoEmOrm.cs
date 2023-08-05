using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloTaxaOuServico
{
	public class RepositorioTaxaOuServicoEmOrm : RepositorioBaseEmOrm<TaxaOuServico>, IRepositorioTaxaOuServico
	{
		public RepositorioTaxaOuServicoEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
		{
		}

		public TaxaOuServico? SelecionarPorNome(string nome)
		{
			return registros.FirstOrDefault(x => x.Nome == nome);
		}
	}
}
