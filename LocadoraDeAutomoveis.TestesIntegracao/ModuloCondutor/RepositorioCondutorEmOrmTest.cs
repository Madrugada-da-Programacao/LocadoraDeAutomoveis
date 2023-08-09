using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraDeAutomoveis.TestesIntegracao.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_condutor()
        {
            //arrange
            var cliente = Builder<Cliente>.CreateNew().Build();
            var condutor = Builder<Condutor>.CreateNew()
                                    .With(c => c.Cliente, cliente)
                                    .Build();

            //action
            RepositorioCondutor.Inserir(condutor);
            ContextoPersistencia.GravarDados();

            //assert
            RepositorioCondutor.SelecionarPorId(condutor.Id).Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_editar_condutor()
        {
            //arrange
            var cliente = Builder<Cliente>.CreateNew().Build();
            var condutorId = Builder<Condutor>.CreateNew().With(c => c.Cliente, cliente).Persist().Id;

            var condutor = RepositorioCondutor.SelecionarPorId(condutorId);
            condutor!.Nome = "Cristian";

            //action
            RepositorioCondutor.Editar(condutor);
            ContextoPersistencia.GravarDados();

            //assert
            RepositorioCondutor.SelecionarPorId(condutor.Id)
                .Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_excluir_condutor()
        {
            //arrange
            var cliente = Builder<Cliente>.CreateNew().Build();
            var condutor = Builder<Condutor>.CreateNew()
                                    .With(c => c.Cliente, cliente)
                                    .Persist();

            //action
            RepositorioCondutor.Excluir(condutor);
            ContextoPersistencia.GravarDados();

            //assert
            RepositorioCondutor.SelecionarPorId(condutor.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_condutores()
        {
            //arrange
            var cliente = Builder<Cliente>.CreateNew().Build();
            var cristian = Builder<Condutor>.CreateNew().With(c => c.Cliente, cliente).Persist();
            var maria = Builder<Condutor>.CreateNew().With(c => c.Cliente, cliente).Persist();

            //action
            var condutores = RepositorioCondutor.SelecionarTodos();

            //assert
            condutores.Should().ContainInOrder(cristian, maria);
            condutores.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_condutor_por_nome()
        {
            //arrange
            var cliente = Builder<Cliente>.CreateNew().Build();
            var cristian = Builder<Condutor>.CreateNew().With(c => c.Cliente, cliente).Persist();

            //action
            var condutorEncontrado = RepositorioCondutor.SelecionarPorNome(cristian.Nome);

            //assert
            condutorEncontrado.Should().Be(cristian);
        }

        [TestMethod]
        public void Deve_selecionar_condutor_por_id()
        {
            //arrange
            var cliente = Builder<Cliente>.CreateNew().Build();
            var cristian = Builder<Condutor>.CreateNew().With(c => c.Cliente, cliente).Persist();

            //action
            var condutorEncontrado = RepositorioCondutor.SelecionarPorId(cristian.Id);

            //assert            
            condutorEncontrado.Should().Be(cristian);
        }
    }
}
