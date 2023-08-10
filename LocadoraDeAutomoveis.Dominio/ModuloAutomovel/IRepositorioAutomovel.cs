using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Dominio.ModuloAutomovel
{
    public interface IRepositorioAutomovel : IRepositorio<Automovel>
    {
        Automovel? SelecionarPorPlaca(string placa);

        List<Automovel>? SelecionarPorGrupo(GrupoDeAutomoveis grupo);

        List<Automovel>? SelecionarTodosComGrupoDeAutomovel();

	}
}
