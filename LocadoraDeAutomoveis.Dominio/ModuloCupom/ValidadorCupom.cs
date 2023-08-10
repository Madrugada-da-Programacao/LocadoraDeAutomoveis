namespace LocadoraDeAutomoveis.Dominio.ModuloCupom
{
	public class ValidadorCupom : AbstractValidator<Cupom>, IValidadorCupom
	{
		public ValidadorCupom()
		{
			RuleFor(x => x.Nome)
				.NotEmpty()
				.NotNull()
				.MinimumLength(3)
				.NaoPodeCaracteresEspeciais();

			RuleFor(x => x.Preco)
				.NotEmpty()
				.NotNull();

			RuleFor(x => x.DataValidade)
				.NotEmpty()
				.NotNull()
				.GreaterThan(p => DateTime.Now)
				.WithMessage("'Data de validade' deve estar no futuro");

			RuleFor(x => x.Parceiro)
				.NotNull();
		}
	}
}
