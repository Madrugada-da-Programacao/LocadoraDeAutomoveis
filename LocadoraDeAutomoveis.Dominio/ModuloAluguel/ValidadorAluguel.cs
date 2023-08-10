using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Dominio.ModuloAluguel
{
    public class ValidadorAluguel : AbstractValidator<Aluguel>, IValidadorAluguel
    {
        public ValidadorAluguel()
        {
            RuleFor(x => x.Funcionario)
                    .NotNull();
            //funcionario cliente grupoauto planocobr condutor automovel
            RuleFor(x => x.Cliente)
                    .NotNull();

            RuleFor(x => x.GrupoDeAutomoveis)
                    .NotNull();

            RuleFor(x => x.PlanoDeCobranca)
                    .NotNull();

            RuleFor(x => x.Condutor)
                    .NotNull();

            RuleFor(x => x.Automovel)
                    .NotNull();
        }
    }
}
