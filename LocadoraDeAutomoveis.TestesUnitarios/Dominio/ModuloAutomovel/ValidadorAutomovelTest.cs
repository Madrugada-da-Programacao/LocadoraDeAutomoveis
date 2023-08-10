using FluentValidation.TestHelper;
using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;

namespace LocadoraDeAutomoveis.TestesUnitarios.Dominio.ModuloAutomovel
{
	[TestClass]
	public class ValidadorAutomovelTest
	{
		private Automovel Automovel { get; set; }
		private ValidadorAutomovel Validador { get; set; }

		public ValidadorAutomovelTest()
		{
			Automovel = new Automovel();

			Validador = new ValidadorAutomovel();
		}

		[TestMethod]
		public void Ano_automovel_deve_ser_menor_que_datetime_now_erro()
		{
			//arrange
			Automovel.Ano = DateTime.Now.AddMonths(1);

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Ano);
		}

		[TestMethod]
		public void Ano_automovel_deve_ser_menor_que_datetime_now_ok()
		{
			//arrange
			Automovel.Ano = DateTime.Now.AddMonths(-1);

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Ano);
		}

		[TestMethod]
		public void Placa_automovel_deve_ser_valida_erro()
		{
			//arrange
			Automovel.Placa ="A2a2aa2a2a2a";

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Placa);
		}

		[TestMethod]
		public void Placa_automovel_deve_ser_valida_formato_antigo_ok()
		{
			//arrange
			Automovel.Placa = "AAA-4444";

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Placa);
		}

		[TestMethod]
		public void Placa_automovel_deve_ser_valida_formato_novo_ok()
		{
			//arrange
			Automovel.Placa = "AAA4A44";

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Placa);
		}

		[TestMethod]
		public void Marca_automovel_deve_ter_no_minimo_3_caracteres_erro()
		{
			//arrange
			Automovel.Marca = "AA";

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Marca);
		}

		[TestMethod]
		public void Marca_automovel_deve_ter_no_minimo_3_caracteres_ok()
		{
			//arrange
			Automovel.Marca = "AAA";

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Marca);
		}

		[TestMethod]
		public void Cor_automovel_deve_ter_no_minimo_3_caracteres_erro()
		{
			//arrange
			Automovel.Cor = "AA";

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Cor);
		}

		[TestMethod]
		public void Cor_automovel_deve_ter_no_minimo_3_caracteres_ok()
		{
			//arrange
			Automovel.Cor = "AAA";

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Cor);
		}

		[TestMethod]
		public void Modelo_automovel_deve_ter_no_minimo_3_caracteres_erro()
		{
			//arrange
			Automovel.Modelo = "AA";

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Modelo);
		}

		[TestMethod]
		public void Modelo_automovel_deve_ter_no_minimo_3_caracteres_ok()
		{
			//arrange
			Automovel.Modelo = "AAA";

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Modelo);
		}

		[TestMethod]
		public void Tipo_do_combustivel_deve_ser_tipo_valido()
		{
			//arrange
			Automovel.TipoCombustivel= Automovel.TiposDeCombustivel.Diesel;

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.TipoCombustivel);
		}

		[TestMethod]
		public void Capacidade_combustivel_deve_ser_tipo_valido()
		{
			//arrange
			Automovel.CapacidadeCombustivel = 1;

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.CapacidadeCombustivel);
		}

		[TestMethod]
		public void Km_deve_ser_tipo_valido()
		{
			//arrange
			Automovel.KM = 0;

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.KM);
		}

		[TestMethod]
		public void Imagem_deve_ser_tipo_valido()
		{
			//arrange
			Automovel.Imagem = new byte[] {1, 2, 3};

			//action
			var resultado = Validador.TestValidate(Automovel);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Imagem);
		}
	}
}
