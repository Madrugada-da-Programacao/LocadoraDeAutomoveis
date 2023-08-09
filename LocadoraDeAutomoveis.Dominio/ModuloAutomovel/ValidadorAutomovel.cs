using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Dominio.ModuloAutomovel
{
    public class ValidadorAutomovel : AbstractValidator<Automovel> , IValidadorAutomovel
    {
        public ValidadorAutomovel()
        {
            RuleFor(x => x.Ano)
                .NotEmpty()
                .NotNull()
                .Matches(@"^\d{4}$")
                .WithMessage("Ano Invalido por favor use o formato: AAAA");
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
                .NotNull();
            RuleFor(x => x.Modelo)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.TipoCombustivel)
                .IsInEnum();
            RuleFor(x => x.CapacidadeCombustivel)
                .NotEmpty()
                .NotNull()
                .Must(CapacidadeCombustivel => CapacidadeCombustivel > 5)
                .WithMessage("A capacidade de combustivel não pode ser negativa ou menor que 5L!");
            RuleFor(x => x.KM)
                .NotEmpty()
                .NotNull()
                .Must(km => km >= 0)
                .WithMessage("A Quilometragem não pode ser menor que 0!");
            RuleFor(x => x.Imagem)
                .NotEmpty()
                .NotNull()
                .Must(imagem => imagem.Length <= 2 * 1024 * 1024)
                .WithMessage("A imagem não pode ser maior do que 2 mb");
        }
    }
}
