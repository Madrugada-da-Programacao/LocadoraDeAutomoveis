using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using FluentValidation.TestHelper;

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
		public void Nome_grupo_de_automoveis_nao_deve_ser_vazio_erro()
		{
			//arrange
			GrupoDeAutomoveis.Nome = "   ";

			//action
			var resultado = Validador.TestValidate(GrupoDeAutomoveis);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Nome);
		}

		[TestMethod]
		public void Nome_grupo_de_automoveis_deve_ter_no_minimo_3_caracteres_erro()
		{
			//arrange
			GrupoDeAutomoveis.Nome = "ab";

			//action
			var resultado = Validador.TestValidate(GrupoDeAutomoveis);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Nome);
		}

		[TestMethod]
		public void Nome_grupo_de_automoveis_deve_ter_no_minimo_3_caracteres_ok()
		{
			//arrange
			GrupoDeAutomoveis.Nome = "abcd";

			//action
			var resultado = Validador.TestValidate(GrupoDeAutomoveis);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Nome);
		}
    }
}
