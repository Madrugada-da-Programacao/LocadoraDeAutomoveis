using FluentValidation.TestHelper;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;

namespace LocadoraDeAutomoveis.TestesUnitarios.Dominio.ModuloTaxaOuServico
{
	[TestClass]
	public class ValidadorTaxaOuServicoTest
	{
		private TaxaOuServico TaxaOuServico { get; set; }
		private ValidadorTaxaOuServico Validador { get; set; }

		public ValidadorTaxaOuServicoTest()
		{
			TaxaOuServico = new TaxaOuServico();
			Validador = new ValidadorTaxaOuServico();
		}

		[TestMethod]
		public void Nome_taxa_ou_servico_nao_deve_ser_vazio_erro()
		{
			//arrange
			TaxaOuServico.Nome = "   ";

			//action
			var resultado = Validador.TestValidate(TaxaOuServico);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Nome);
		}

		[TestMethod]
		public void Nome_taxa_ou_servico_deve_ter_no_minimo_3_caracteres_erro()
		{
			//arrange
			TaxaOuServico.Nome = "ab";

			//action
			var resultado = Validador.TestValidate(TaxaOuServico);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Nome);
		}

		[TestMethod]
		public void Nome_taxa_ou_servico_deve_ter_no_minimo_3_caracteres_ok()
		{
			//arrange
			TaxaOuServico.Nome = "abcd";

			//action
			var resultado = Validador.TestValidate(TaxaOuServico);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Nome);
		}

		[TestMethod]
		public void Preco_taxa_ou_servico_nao_deve_ser_nulo_ou_vazio_ok()
		{
			//arrange
			TaxaOuServico.Preco = 1;

			//action
			var resultado = Validador.TestValidate(TaxaOuServico);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Preco);
		}

		[TestMethod]
		public void Tipo_da_taxa_ou_servico_deve_ser_tipo_valido()
		{
			//arrange
			TaxaOuServico.TipoCobranca = TaxaOuServico.TipoDeCobranca.PrecoFixo;

			//action
			var resultado = Validador.TestValidate(TaxaOuServico);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.TipoCobranca);
		}
	}
}
