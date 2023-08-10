using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis
{
    public interface IRepositorioGrupoDeAutomoveis : IRepositorio<GrupoDeAutomoveis>
    {
        GrupoDeAutomoveis? SelecionarPorNome(string nome);
    }
}
