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

            RuleFor(x => x.TipoDeCobranca)
					.IsInEnum();

			RuleFor(x => x.Condutor)
                    .NotNull();

            RuleFor(x => x.Automovel)
                    .NotNull();
        }
    }
}
