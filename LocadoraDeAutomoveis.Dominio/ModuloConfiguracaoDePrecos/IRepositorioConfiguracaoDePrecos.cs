using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos
{
    public interface IRepositorioConfiguracaoDePrecos : IRepositorio<ConfiguracaoDePrecos>
    {
        public abstract ConfiguracaoDePrecos SelecionarRegistro();

        public abstract void Editar();
    }
}
