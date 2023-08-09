namespace LocadoraDeAutomoveis.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>, IValidadorCondutor
    {
        public ValidadorCondutor()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Formato de email invalido.");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .NotNull()
                .Matches(@"^\(\d{2}\) \d \d{4}-\d{4}$")
                .WithMessage("Formato invalido para numero de telefone. Use o padrão: (00) 0 0000-0000");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .NotNull()
                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
                .WithMessage("Formato invalido para CPF. Use o padrão: 000.000.000-00");

            RuleFor(x => x.Cnh)
                .NotEmpty()
                .NotNull()
                .Length(12);

            RuleFor(x => x.Validade)
                .NotEmpty()
                .NotNull()
                .GreaterThan(p => DateTime.Now)
                .WithMessage("'Validade' deve estar no futuro");
        }
    }
}
