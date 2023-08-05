namespace LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico
{
	public class ValidadorTaxaOuServico : AbstractValidator<TaxaOuServico>, IValidadorTaxaOuServico
	{
		public ValidadorTaxaOuServico()
		{
			RuleFor(x => x.Nome)
				.NotEmpty()
				.NotNull()
				.MinimumLength(3)
				.NaoPodeCaracteresEspeciais();

			RuleFor(x => x.Preco)
				.NotEmpty()
				.NotNull();

			RuleFor(x => x.TipoCobranca)
				.IsInEnum();
		}
	}
}
