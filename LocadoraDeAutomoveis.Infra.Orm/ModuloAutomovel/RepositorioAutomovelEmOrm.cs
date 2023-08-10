using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloAutomovel
{
    public class RepositorioAutomovelEmOrm : RepositorioBaseEmOrm<Automovel> , IRepositorioAutomovel
    {
        public RepositorioAutomovelEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext) { }

        public Automovel? SelecionarPorPlaca(string placa)
        {
            return registros.FirstOrDefault(x => x.Placa == placa);
        }

        public List<Automovel>? SelecionarPorGrupo(GrupoDeAutomoveis grupoDeAutomoveis)
        {
            return registros.Where(x => x.GrupoDeAutomovel == grupoDeAutomoveis).ToList();
        }

		public List<Automovel>? SelecionarTodosComGrupoDeAutomovel()
		{
			return registros.Include(a => a.GrupoDeAutomovel).ToList();
		}
	}
}
