using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
