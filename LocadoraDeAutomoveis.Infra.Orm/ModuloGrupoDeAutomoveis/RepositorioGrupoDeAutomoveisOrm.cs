using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloGrupoDeAutomoveis
{
    public class RepositorioGrupoDeAutomoveisOrm : RepositorioBaseEmOrm<GrupoDeAutomoveis>, IRepositorioGrupoDeAutomoveis
    {
        public RepositorioGrupoDeAutomoveisOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext) {}

        public GrupoDeAutomoveis? SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
