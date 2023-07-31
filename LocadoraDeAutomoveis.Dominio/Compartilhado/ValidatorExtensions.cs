using FluentValidation;

namespace LocadoraDeAutomoveis.Dominio.Compartilhado
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> NaoPodeCaracteresEspeciais<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new NaoPodeCaracteresEspeciaisValidator<T>());
        }
    }
}
