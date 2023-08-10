namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoDeCobranca : AbstractValidator<PlanoDeCobranca>, IValidadorPlanoDeCobranca
    {
        public ValidadorPlanoDeCobranca()
        {

            RuleFor(x => x.GrupoDeAutomoveis)
                .NotNull();

            RuleFor(x => x.TipoDoPlano)
                .IsInEnum();

            RuleFor(x => x.PrecoDiariaPlanoDiario)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PrecoKmPlanoDiario)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PrecoDiariaKmControlado)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PrecoKmExtrapoladoKmControlado)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.KmDisponiveisKmControlado)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PrecoDiariaKmLivre)
                .NotEmpty()
                .NotNull();
        }
    }
}
