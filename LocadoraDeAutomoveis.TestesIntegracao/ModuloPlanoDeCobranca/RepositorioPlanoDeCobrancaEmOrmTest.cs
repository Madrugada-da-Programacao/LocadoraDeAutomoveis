using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;
using static LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca.PlanoDeCobranca;

namespace LocadoraDeAutomoveis.TestesIntegracao.ModuloPlanoDeCobranca
{
    [TestClass]
    public class RepositorioPlanoDeCobrancaEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_plano_de_cobranca()
        {
            //arrange
            var planoDeCobranca = Builder<PlanoDeCobranca>.CreateNew().Build();

            //action
            RepositorioPlanoDeCobranca.Inserir(planoDeCobranca);

            //assert
            RepositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id).Should().Be(planoDeCobranca);
        }

        [TestMethod]
        public void Deve_editar_plano_de_cobranca()
        {
            //arrange
            var planoDeCobrancaId = Builder<PlanoDeCobranca>.CreateNew().Persist().Id;

            var planoDeCobranca = RepositorioPlanoDeCobranca.SelecionarPorId(planoDeCobrancaId);
            planoDeCobranca!.TipoDoPlano = TipoDoPlanoEnum.PlanoDiario;

            //action
            RepositorioPlanoDeCobranca.Editar(planoDeCobranca);

            //assert
            RepositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id)
                .Should().Be(planoDeCobranca);
        }

        [TestMethod]
        public void Deve_excluir_plano_de_cobranca()
        {
            //arrange
            var planoDeCobranca = Builder<PlanoDeCobranca>.CreateNew().Persist();

            //action
            RepositorioPlanoDeCobranca.Excluir(planoDeCobranca);

            //assert
            RepositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_plano_de_cobrancas()
        {
            //arrange
            var plano1 = Builder<PlanoDeCobranca>.CreateNew().Persist();
            var plano2 = Builder<PlanoDeCobranca>.CreateNew().Persist();

            //action
            var planoDeCobrancas = RepositorioPlanoDeCobranca.SelecionarTodos();

            //assert
            planoDeCobrancas.Should().ContainInOrder(plano1, plano2);
            planoDeCobrancas.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_plano_de_cobranca_por_id()
        {
            //arrange
            var plano = Builder<PlanoDeCobranca>.CreateNew().Persist();

            //action
            var planoDeCobrancaEncontrado = RepositorioPlanoDeCobranca.SelecionarPorId(plano.Id);

            //assert            
            planoDeCobrancaEncontrado.Should().Be(plano);
        }
    }
}
