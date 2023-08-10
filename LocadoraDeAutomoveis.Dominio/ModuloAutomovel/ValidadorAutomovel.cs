namespace LocadoraDeAutomoveis.Dominio.ModuloAutomovel
{
    public class ValidadorAutomovel : AbstractValidator<Automovel> , IValidadorAutomovel
    {
        public ValidadorAutomovel()
        {
            RuleFor(x => x.Ano)
                .NotEmpty()
                .NotNull()
                .LessThan(DateTime.Now);

            RuleFor(x => x.Placa)
                .NotEmpty()
                .NotNull()
                .Matches(@"^([A-Z]{3}-\d{4})|([A-Z]{3}\d{1}[A-Z]{1}\d{2})$")
                .WithMessage("Placa Invalida por favor utilize um dos formatos padrões Brasileiros: AAA-0000 ou AAA0A00");
            RuleFor(x => x.Marca)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .NaoPodeCaracteresEspeciais();
            RuleFor(x => x.Cor)
                .NotEmpty()
                .NotNull()
				.MinimumLength(3);
            RuleFor(x => x.Modelo)
                .NotEmpty()
                .NotNull()
				.MinimumLength(3);
            RuleFor(x => x.TipoCombustivel)
                .IsInEnum();
            RuleFor(x => x.CapacidadeCombustivel)
                .NotEmpty()
                .NotNull()
                .Must(CapacidadeCombustivel => CapacidadeCombustivel >= 1)
                .WithMessage("A capacidade de combustivel tem que ser maior ou igual a 1!");
            RuleFor(x => x.KM)
                .NotNull()
                .Must(km => km >= 0)
                .WithMessage("A Quilometragem não pode ser menor que 0!");
            RuleFor(x => x.Imagem)
                .NotEmpty()
                .NotNull()
                .Must(imagem => imagem != null && imagem.Length <= 2 * 1024 * 1024)
                .WithMessage("A imagem não pode ser maior do que 2 mb");
        }
    }
}
