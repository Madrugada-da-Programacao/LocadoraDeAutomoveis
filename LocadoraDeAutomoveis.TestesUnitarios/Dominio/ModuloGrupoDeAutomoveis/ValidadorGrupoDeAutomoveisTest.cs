using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using FluentValidation.TestHelper;
using LocadoraDeAutomoveis.Dominio;

namespace LocadoraDeAutomoveis.TestesUnitarios.Dominio.ModuloGrupoDeAutomoveis
{
    [TestClass]
    public class ValidadorGrupoDeAutomoveisTest
    {
        private GrupoDeAutomoveis GrupoDeAutomoveis { get; set; }
        private ValidadorGrupoDeAutomoveis Validador { get; set; }

        public ValidadorGrupoDeAutomoveisTest()
        {
            GrupoDeAutomoveis = new GrupoDeAutomoveis();
            Validador = new ValidadorGrupoDeAutomoveis();
        }

        [TestMethod]
        public void nome_nao_deve_ser_nulo_erro()
        {
            var resultado = Validador.TestValidate(GrupoDeAutomoveis);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void nome_nao_deve_ser_nulo_ok()
        {
            GrupoDeAutomoveis.Nome = "Teste";

            var resultado = Validador.TestValidate(GrupoDeAutomoveis);

            resultado.ShouldNotHaveValidationErrorFor(x => x.Nome);
        }
    }
}
