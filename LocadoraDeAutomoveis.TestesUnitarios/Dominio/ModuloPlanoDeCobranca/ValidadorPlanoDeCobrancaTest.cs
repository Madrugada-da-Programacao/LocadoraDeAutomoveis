using FluentAssertions;
using FluentValidation.TestHelper;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
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
        public void Grupo_de_automoveis_nao_deve_ser_nulo()
        {
            PlanoDeCobranca plano = new PlanoDeCobranca();

            GrupoDeAutomoveis grupo = new GrupoDeAutomoveis();

            plano.GrupoDeAutomoveis = grupo;

            plano.GrupoDeAutomoveis.Should().NotBeNull();
        }

        [TestMethod]
        public void Preco_diaria_plano_diario_plano_de_cobranca_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            PlanoDeCobranca.PrecoDiariaPlanoDiario = 1;

            //action
            var resultado = Validador.TestValidate(PlanoDeCobranca);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.PrecoDiariaPlanoDiario);
        }

        [TestMethod]
        public void Preco_km_plano_diario_plano_de_cobranca_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            PlanoDeCobranca.PrecoKmPlanoDiario = 1;

            //action
            var resultado = Validador.TestValidate(PlanoDeCobranca);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.PrecoKmPlanoDiario);
        }

        [TestMethod]
        public void Preco_diaria_km_controlado_plano_de_cobranca_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            PlanoDeCobranca.PrecoDiariaKmControlado = 1;

            //action
            var resultado = Validador.TestValidate(PlanoDeCobranca);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.PrecoDiariaKmControlado);
        }

        [TestMethod]
        public void Preco_km_extrapolado_km_controlado_plano_de_cobranca_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            PlanoDeCobranca.PrecoKmExtrapoladoKmControlado = 1;

            //action
            var resultado = Validador.TestValidate(PlanoDeCobranca);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.PrecoKmExtrapoladoKmControlado);
        }

        [TestMethod]
        public void Km_disponiveis_km_controlado_plano_de_cobranca_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            PlanoDeCobranca.KmDisponiveisKmControlado = 1;

            //action
            var resultado = Validador.TestValidate(PlanoDeCobranca);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.KmDisponiveisKmControlado);
        }

        public void Preco_diaria_km_livre_plano_de_cobranca_nao_deve_ser_nulo_ou_vazio_erro()
        {
            //action
            var resultado = Validador.TestValidate(PlanoDeCobranca);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.PrecoDiariaKmLivre);
        }

        [TestMethod]
        public void Preco_diaria_km_livre_plano_de_cobranca_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            PlanoDeCobranca.PrecoDiariaKmLivre = 1;

            //action
            var resultado = Validador.TestValidate(PlanoDeCobranca);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.PrecoDiariaKmLivre);
        }

        //TODO validador aluguel
    }
}
