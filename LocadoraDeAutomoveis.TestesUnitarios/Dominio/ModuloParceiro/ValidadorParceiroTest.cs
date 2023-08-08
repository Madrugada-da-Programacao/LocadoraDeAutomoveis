using FluentValidation.TestHelper;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraDeAutomoveis.TestesUnitarios.Dominio.ModuloParceiro
{
	[TestClass]
	public class ValidadorParceiroTest
	{
		private Parceiro Parceiro { get; set; }
		private ValidadorParceiro Validador { get; set; }

		public ValidadorParceiroTest()
		{
			Parceiro = new Parceiro();
			Validador = new ValidadorParceiro();
		}

		[TestMethod]
		public void Nome_parceiro_nao_deve_ser_vazio_erro()
		{
			//arrange
			Parceiro.Nome = "   ";

			//action
			var resultado = Validador.TestValidate(Parceiro);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Nome);
		}

		[TestMethod]
		public void Nome_parceiro_deve_ter_no_minimo_3_caracteres_erro()
		{
			//arrange
			Parceiro.Nome = "ab";

			//action
			var resultado = Validador.TestValidate(Parceiro);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Nome);
		}

		[TestMethod]
		public void Nome_parceiro_deve_ter_no_minimo_3_caracteres_ok()
		{
			//arrange
			Parceiro.Nome = "abc";

			//action
			var resultado = Validador.TestValidate(Parceiro);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Nome);
		}
	}
}
