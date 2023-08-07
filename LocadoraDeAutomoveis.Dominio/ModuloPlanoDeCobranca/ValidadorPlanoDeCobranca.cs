namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoDeCobranca : AbstractValidator<PlanoDeCobranca>, IValidadorPlanoDeCobranca
    {
        public ValidadorPlanoDeCobranca()
        {

            RuleFor(x => x.TipoDoPlano)
                .IsInEnum();

            RuleFor(x => x.PrecoDiaria)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PrecoKm)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.KmDisponiveis)
                .NotEmpty()
                .NotNull();
        }
    }
}
