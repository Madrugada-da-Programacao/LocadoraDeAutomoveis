namespace LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos
{
    public class ValidadorConfiguracaoDePrecos : AbstractValidator<ConfiguracaoDePrecos>, IValidadorConfiguracaoDePrecos
    {
        public ValidadorConfiguracaoDePrecos()
        {
            
            RuleFor(x => x.Gasolina)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Gas)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Diesel)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Alcool)
                .NotEmpty()
                .NotNull();

        }
    }
}
