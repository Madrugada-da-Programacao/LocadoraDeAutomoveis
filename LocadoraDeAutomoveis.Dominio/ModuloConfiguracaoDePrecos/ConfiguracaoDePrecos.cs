using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos
{
    public class ConfiguracaoDePrecos : EntidadeBase<ConfiguracaoDePrecos>
    {
        public decimal Gasolina { get; set; }
        public decimal Gas { get; set; }
        public decimal Diesel { get; set; }
        public decimal Alcool { get; set; }

        public ConfiguracaoDePrecos(decimal gasolina, decimal gas, decimal diesel, decimal alcool)
        {
            Gasolina = gasolina;
            Gas = gas;
            Diesel = diesel;
            Alcool = alcool;
        }

        public ConfiguracaoDePrecos()
        {
        }
    }
}
