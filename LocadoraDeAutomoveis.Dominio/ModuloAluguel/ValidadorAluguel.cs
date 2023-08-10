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

            RuleFor(x => x.DataLocacao)
                .NotEmpty()
                .NotNull()
                .LessThan(p => DateTime.Now)
                .WithMessage("'Data de Locação' deve estar no passado");

            RuleFor(x => x.DataDevolucaoPrevista)
                .NotEmpty()
                .NotNull()
                .GreaterThan(p => DateTime.Now)
                .WithMessage("'Data de Devolução Prevista' deve estar no futuro");

            RuleFor(x => x.Taxas)
                .NotNull();

            RuleFor(x => x.ValorTotal)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Aberto)
                .NotNull();
        }
    }
}
