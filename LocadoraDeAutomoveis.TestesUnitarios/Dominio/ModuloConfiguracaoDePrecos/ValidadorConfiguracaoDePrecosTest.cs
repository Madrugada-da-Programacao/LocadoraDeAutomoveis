using FluentValidation.TestHelper;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos;

namespace LocadoraDeAutomoveis.TestesUnitarios.Dominio.ModuloConfiguracaoDePrecos
{
    [TestClass]
    public class ValidadorConfiguracaoDePrecosTest
    {
        private ConfiguracaoDePrecos ConfiguracaoDePrecos { get; set; }
        private ValidadorConfiguracaoDePrecos Validador { get; set; }

		public ValidadorConfiguracaoDePrecosTest()
        {
			ConfiguracaoDePrecos = new ConfiguracaoDePrecos();

			Validador = new ValidadorConfiguracaoDePrecos();
        }

        [TestMethod]
		public void Gasolina_configuracaoDePrecos_nao_deve_ser_nulo_ou_vazio_ok()
		{
			//arrange
			ConfiguracaoDePrecos.Gasolina = 1;

			//action
			var resultado = Validador.TestValidate(ConfiguracaoDePrecos);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Gasolina);
		}

        [TestMethod]
        public void Gas_configuracaoDePrecos_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            ConfiguracaoDePrecos.Gas = 1;

            //action
            var resultado = Validador.TestValidate(ConfiguracaoDePrecos);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.Gas);
        }

        [TestMethod]
        public void Diesel_configuracaoDePrecos_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            ConfiguracaoDePrecos.Diesel = 1;

            //action
            var resultado = Validador.TestValidate(ConfiguracaoDePrecos);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.Diesel);
        }

        [TestMethod]
        public void Alcool_configuracaoDePrecos_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            ConfiguracaoDePrecos.Alcool = 1;

            //action
            var resultado = Validador.TestValidate(ConfiguracaoDePrecos);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.Alcool);
        }
    }
}
