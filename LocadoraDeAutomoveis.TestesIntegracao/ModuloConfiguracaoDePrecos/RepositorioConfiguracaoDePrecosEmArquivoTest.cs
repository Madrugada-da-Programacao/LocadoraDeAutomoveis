using FluentAssertions;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos;

namespace LocadoraDeAutomoveis.TestesIntegracao.ModuloConfiguracaoDePrecos
{
    [TestClass]
    public class RepositorioConfiguracaoDePrecosEmArquivoTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_editar_configuracaoDePrecos()
        {
            //arrange
            Contexto.ConfiguracaoDePrecos = new ConfiguracaoDePrecos(5, 5, 5, 5);

            //action
            RepositorioConfiguracaoDePrecos.Editar();

            //assert
            RepositorioConfiguracaoDePrecos.SelecionarRegistro()
                .Should().Be(Contexto.ConfiguracaoDePrecos);
        }

        [TestMethod]
        public void Deve_selecionar_configuracaoDePrecos()
        {
            //arrange
            Contexto.ConfiguracaoDePrecos = new ConfiguracaoDePrecos(5, 5, 5, 5);

            RepositorioConfiguracaoDePrecos.Editar();

            //action
            var configuracaoDePrecos = RepositorioConfiguracaoDePrecos.SelecionarRegistro();

            //assert
            configuracaoDePrecos.Should().Be(Contexto.ConfiguracaoDePrecos);
        }
    }
}