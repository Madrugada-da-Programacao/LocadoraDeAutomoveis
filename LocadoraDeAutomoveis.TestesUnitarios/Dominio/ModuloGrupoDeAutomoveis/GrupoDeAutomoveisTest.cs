using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.TestesUnitarios.Dominio.ModuloGrupoDeAutomoveis
{
    [TestClass]
    public class GrupoDeAutomoveisTest
    {
        private GrupoDeAutomoveis GrupoDeAutomoveis {  get; set; }

        public GrupoDeAutomoveisTest()
        {
            GrupoDeAutomoveis = new GrupoDeAutomoveis();
        }
    }
}
