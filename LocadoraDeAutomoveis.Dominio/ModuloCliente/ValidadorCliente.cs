using static LocadoraDeAutomoveis.Dominio.Cliente;

namespace LocadoraDeAutomoveis.Dominio.ModuloCliente
{
	public class ValidadorCliente : AbstractValidator<Cliente>, IValidadorCliente
	{
		public ValidadorCliente()
		{
			RuleFor(x => x.Nome)
				.NotEmpty()
				.NotNull()
				.MinimumLength(3)
				.NaoPodeCaracteresEspeciais();

			RuleFor(x => x.TipoCliente)
				.IsInEnum();

			When(x => x.TipoCliente == TipoDeCliente.PessoaFisica, () =>
			{
				RuleFor(x => x.NumeroDoDocumento)
					.NotEmpty()
					.NotNull()
					.Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
					.WithMessage("Formato invalido para CPF. Use o padrão: 000.000.000-00");
			});

			When(x => x.TipoCliente == TipoDeCliente.PessoaJuridica, () =>
			{
				RuleFor(x => x.NumeroDoDocumento)
					.NotEmpty()
					.NotNull()
					.Matches(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$")
					.WithMessage("Formato invalido para CNPJ. Use o padrão: 00.000.000/0000-00");
			});

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

			RuleFor(x => x.Estado)
				.NotEmpty()
				.NotNull()
				.MinimumLength(2)
				.NaoPodeCaracteresEspeciais();

			RuleFor(x => x.Cidade)
				.NotEmpty()
				.NotNull()
				.MinimumLength(2)
				.NaoPodeCaracteresEspeciais();

			RuleFor(x => x.Bairro)
				.NotEmpty()
				.NotNull()
				.MinimumLength(2)
				.NaoPodeCaracteresEspeciais();

			RuleFor(x => x.Rua)
				.NotEmpty()
				.NotNull()
				.MinimumLength(2)
				.NaoPodeCaracteresEspeciais();

			RuleFor(x => x.Numero)
				.NotEmpty()
				.NotNull();
		}
	}
}
