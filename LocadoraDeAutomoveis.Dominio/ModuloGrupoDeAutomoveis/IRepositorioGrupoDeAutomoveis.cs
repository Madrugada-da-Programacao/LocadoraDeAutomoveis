﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis
{
    public interface IRepositorioGrupoDeAutomoveis : IRepositorio<GrupoDeAutomoveis>
    {
        List<GrupoDeAutomoveis> SelecionarGruposComPlano();
        GrupoDeAutomoveis? SelecionarPorNome(string nome);
    }
}
