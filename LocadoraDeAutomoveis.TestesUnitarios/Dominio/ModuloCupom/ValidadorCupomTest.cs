using FluentValidation.TestHelper;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCupom;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.Dominio.ModuloParceiro;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;

namespace LocadoraDeAutomoveis.TestesUnitarios.Dominio.ModuloCupom
{
	[TestClass]
	public class ValidadorCupomTest
	{
		private Cupom Cupom { get; set; }
		private ValidadorCupom Validador { get; set; }

		public ValidadorCupomTest()
		{
			Cupom = new Cupom();

			Validador = new ValidadorCupom();
		}

		[TestMethod]
		public void Nome_cupom_nao_deve_ser_vazio_erro()
		{
			//arrange
			Cupom.Nome = "   ";

			//action
			var resultado = Validador.TestValidate(Cupom);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Nome);
		}

		[TestMethod]
		public void Nome_cupom_deve_ter_no_minimo_3_caracteres_erro()
		{
			//arrange
			Cupom.Nome = "ab";

			//action
			var resultado = Validador.TestValidate(Cupom);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Nome);
		}

		[TestMethod]
		public void Nome_cupom_deve_ter_no_minimo_3_caracteres_ok()
		{
			//arrange
			Cupom.Nome = "abc";

			//action
			var resultado = Validador.TestValidate(Cupom);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Nome);
		}

		[TestMethod]
		public void Preco_cupom_nao_deve_ser_nulo_ou_vazio_ok()
		{
			//arrange
			Cupom.Preco = 1;

			//action
			var resultado = Validador.TestValidate(Cupom);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Preco);
		}

		[TestMethod]
		public void DataValidade_cupom_nao_deve_ser_nulo_ou_vazio_erro()
		{
			//action
			var resultado = Validador.TestValidate(Cupom);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.DataValidade);
		}

		[TestMethod]
		public void DataValidade_cupom_nao_deve_ser_nulo_ou_vazio_ok()
		{
			//arrange
			Cupom.DataValidade = DateTime.Now.AddMonths(1);

			//action
			var resultado = Validador.TestValidate(Cupom);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.DataValidade);
		}

		[TestMethod]
		public void Parceiro_cupom_nao_deve_ser_nulo_erro()
		{
			//action
			var resultado = Validador.TestValidate(Cupom);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Parceiro);
		}

		[TestMethod]
		public void Parceiro_cupom_nao_deve_ser_nulo_ok()
		{
			//arrange
			Cupom.Parceiro = new Parceiro();

			//action
			var resultado = Validador.TestValidate(Cupom);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Parceiro);
		}
	}
}
