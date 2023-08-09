using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
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
            var grupoDeAutomoveis = Builder<GrupoDeAutomoveis>.CreateNew().Build();
            var planoDeCobranca = Builder<PlanoDeCobranca>.CreateNew()
                                   .With(c => c.GrupoDeAutomoveis, grupoDeAutomoveis)
                                   .Build();

            //action
            RepositorioPlanoDeCobranca.Inserir(planoDeCobranca);

            //assert
            RepositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id).Should().Be(planoDeCobranca);
        }

        [TestMethod]
        public void Deve_editar_plano_de_cobranca()
        {
            //arrange
            var grupoDeAutomoveis = Builder<GrupoDeAutomoveis>.CreateNew().Build();

            var planoDeCobrancaId = Builder<PlanoDeCobranca>.CreateNew().With(c => c.GrupoDeAutomoveis, grupoDeAutomoveis).Persist().Id;

            var planoDeCobranca = RepositorioPlanoDeCobranca.SelecionarPorId(planoDeCobrancaId);
            planoDeCobranca!.PrecoDiariaPlanoDiario = 5m;

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
            var grupoDeAutomoveis = Builder<GrupoDeAutomoveis>.CreateNew().Build();
            var planoDeCobranca = Builder<PlanoDeCobranca>.CreateNew()
                                   .With(c => c.GrupoDeAutomoveis, grupoDeAutomoveis)
                                   .Persist();

            //action
            RepositorioPlanoDeCobranca.Excluir(planoDeCobranca);

            //assert
            RepositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_plano_de_cobrancas()
        {
            //arrange
            var grupo1 = Builder<GrupoDeAutomoveis>.CreateNew().Build();
            var plano1 = Builder<PlanoDeCobranca>.CreateNew()
                                   .With(c => c.GrupoDeAutomoveis, grupo1)
                                   .Persist();
            var grupo2 = Builder<GrupoDeAutomoveis>.CreateNew().Build();
            var plano2 = Builder<PlanoDeCobranca>.CreateNew()
                                   .With(c => c.GrupoDeAutomoveis, grupo2)
                                   .Persist();

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
            var grupoDeAutomoveis = Builder<GrupoDeAutomoveis>.CreateNew().Build();
            var planoDeCobranca = Builder<PlanoDeCobranca>.CreateNew()
                                   .With(c => c.GrupoDeAutomoveis, grupoDeAutomoveis)
                                   .Persist();

            //action
            var planoDeCobrancaEncontrado = RepositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);

            //assert            
            planoDeCobrancaEncontrado.Should().Be(planoDeCobranca);
        }
    }
}
