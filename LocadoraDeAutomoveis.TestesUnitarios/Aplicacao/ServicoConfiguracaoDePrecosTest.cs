using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos;
using Moq;

namespace LocadoraDeAutomoveis.TestesUnitarios.Aplicacao
{
    [TestClass]
    public class ServicoConfiguracaoDePrecosTest
    {
        Mock<IRepositorioConfiguracaoDePrecos> RepositorioConfiguracaoDePrecosMoq { get; set; }
        Mock<IValidadorConfiguracaoDePrecos> ValidodorMoq { get; set; }

        private ServicoConfiguracaoDePrecos ServicoConfiguracaoDePrecos { get; set; }

        ConfiguracaoDePrecos ConfiguracaoDePrecos { get; set; }

        public ServicoConfiguracaoDePrecosTest()
        {
            RepositorioConfiguracaoDePrecosMoq = new Mock<IRepositorioConfiguracaoDePrecos>();
            ValidodorMoq = new Mock<IValidadorConfiguracaoDePrecos>();
            ServicoConfiguracaoDePrecos = new ServicoConfiguracaoDePrecos(RepositorioConfiguracaoDePrecosMoq.Object, ValidodorMoq.Object);
            ConfiguracaoDePrecos = new ConfiguracaoDePrecos(10, 10, 10, 10);
        }

        [TestMethod]
        public void Deve_editar_configuracaoDePrecos_caso_ele_for_valido() //cenário 1
        {
            //action
            Result resultado = ServicoConfiguracaoDePrecos.Editar(ConfiguracaoDePrecos);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioConfiguracaoDePrecosMoq.Verify(x => x.Editar(ConfiguracaoDePrecos), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_configuracaoDePrecos_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            ValidodorMoq.Setup(x => x.Validate(It.IsAny<ConfiguracaoDePrecos>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Gasolina", "O campo 'Gasolina' é obrigatório"));
                    return resultado;
                });

            //action
            var resultado = ServicoConfiguracaoDePrecos.Editar(ConfiguracaoDePrecos);

            //assert             
            resultado.Should().BeFailure();
            RepositorioConfiguracaoDePrecosMoq.Verify(x => x.Editar(ConfiguracaoDePrecos), Times.Never());
        }

    }
}
