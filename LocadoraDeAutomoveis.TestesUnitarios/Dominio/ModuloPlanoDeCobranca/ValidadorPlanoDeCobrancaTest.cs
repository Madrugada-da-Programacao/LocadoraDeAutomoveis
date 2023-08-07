using FluentValidation.TestHelper;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.TestesUnitarios.Dominio.ModuloPlanoDeCobranca
{
    [TestClass]
    public class ValidadorPlanoDeCobrancaTest
    {
        private PlanoDeCobranca PlanoDeCobranca { get; set; }
        private ValidadorPlanoDeCobranca Validador { get; set; }

        public ValidadorPlanoDeCobrancaTest()
        {
            PlanoDeCobranca = new PlanoDeCobranca();

            Validador = new ValidadorPlanoDeCobranca();
        }

        [TestMethod]
        public void Tipo_do_plano_de_cobranca_deve_ser_tipo_valido()
        {
            //arrange
            PlanoDeCobranca.TipoDoPlano = PlanoDeCobranca.TipoDoPlanoEnum.PlanoDiario;

            //action
            var resultado = Validador.TestValidate(PlanoDeCobranca);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.TipoDoPlano);
        }

        //[TestMethod]
        //public void Preco_diaria_plano_de_cobranca_nao_deve_ser_nulo_ou_vazio_erro()
        //{
        //	//action
        //	var resultado = Validador.TestValidate(PlanoDeCobranca);

        //	//assert
        //	resultado.ShouldHaveValidationErrorFor(x => x.PrecoDiaria);
        //}

        [TestMethod]
        public void Preco_diaria_plano_de_cobranca_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            PlanoDeCobranca.PrecoDiaria = 1;

            //action
            var resultado = Validador.TestValidate(PlanoDeCobranca);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.PrecoDiaria);
        }

        //[TestMethod]
        //public void Preco_km_plano_de_cobranca_nao_deve_ser_nulo_ou_vazio_erro()
        //{
        //	//action
        //	var resultado = Validador.TestValidate(PlanoDeCobranca);

        //	//assert
        //	resultado.ShouldHaveValidationErrorFor(x => x.PrecoKm);
        //}

        [TestMethod]
        public void Preco_km_plano_de_cobranca_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            PlanoDeCobranca.PrecoKm = 1;

            //action
            var resultado = Validador.TestValidate(PlanoDeCobranca);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.PrecoKm);
        }

        //[TestMethod]
        //public void Km_disponiveis_plano_de_cobranca_nao_deve_ser_nulo_ou_vazio_erro()
        //{
        //	//action
        //	var resultado = Validador.TestValidate(PlanoDeCobranca);

        //	//assert
        //	resultado.ShouldHaveValidationErrorFor(x => x.KmDisponiveis);
        //}

        [TestMethod]
        public void Km_disponiveis_plano_de_cobranca_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            PlanoDeCobranca.KmDisponiveis = 1;

            //action
            var resultado = Validador.TestValidate(PlanoDeCobranca);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.KmDisponiveis);
        }
    }
}
