using LocadoraDeAutomoveis.Dominio;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloCliente
{
	public class RepositorioClienteEmOrm : RepositorioBaseEmOrm<Cliente>, IRepositorioCliente
	{
		public RepositorioClienteEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
		{
		}

		public Cliente? SelecionarPorNomeETipoDeCliente(string nome, Cliente.TipoDeCliente tipoDeCliente)
		{
			return registros.FirstOrDefault(x => x.Nome == nome && x.TipoCliente == tipoDeCliente);
		}
	}
}
