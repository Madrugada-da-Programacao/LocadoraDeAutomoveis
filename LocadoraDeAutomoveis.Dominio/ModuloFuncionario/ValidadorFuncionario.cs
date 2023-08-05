namespace LocadoraDeAutomoveis.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>, IValidadorFuncionario
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.DataAdmissao)
                .NotEmpty()
                .NotNull()
                .LessThan(p => DateTime.Now)
                .WithMessage("'Data de Admissão' deve estar no passado");

            RuleFor(x => x.Salario)
                .NotEmpty()
                .NotNull();

        }
    }
}
