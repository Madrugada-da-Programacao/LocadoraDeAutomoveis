using FluentValidation;
using FluentValidation.Validators;

namespace LocadoraDeAutomoveis.Dominio.Compartilhado
{
    public class NaoPodeCaracteresEspeciaisValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "NaoPodeCaracteresEspeciaisValidator";

        private string nomePropriedade;

        protected override string GetDefaultMessageTemplate(string errorCode)
        {            
            return $"'{nomePropriedade}' deve ser composto por letras e números.";
        }

        public override bool IsValid(ValidationContext<T> contextoValidacao, string texto)
        {
            nomePropriedade = contextoValidacao.DisplayName;

            if (string.IsNullOrEmpty(texto))
                return false;

            bool estaValido = true;

            foreach (char letra in texto)
            {
                if (letra == ' ')
                    continue;

                if (char.IsLetterOrDigit(letra) == false)
                {
                    estaValido = false;                    
                    break;
                }
            }

            return estaValido;
        }

        
    }
}
