using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeAutomoveis.Dominio;

namespace LocadoraDeAutomoveis.TestesIntegracao.ModuloDisciplina
{
    [TestClass]
    public class RepositorioClienteEmORmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_cliente()
        {            
            //arrange
            var cliente = Builder<Cliente>.CreateNew().Build();

            //action
            RepositorioCliente.Inserir(cliente);

			//assert
			RepositorioCliente.SelecionarPorId(cliente.Id).Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_editar_cliente()
        {
            //arrange
            var clienteId = Builder<Cliente>.CreateNew().Persist().Id;

            var cliente = RepositorioCliente.SelecionarPorId(clienteId);
            cliente.Nome = "Ricardo";

            //action
            RepositorioCliente.Editar(cliente);

            //assert
            RepositorioCliente.SelecionarPorId(cliente.Id)
                .Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_excluir_cliente()
        {
            //arrange
            var cliente = Builder<Cliente>.CreateNew().Persist();

            //action
            RepositorioCliente.Excluir(cliente);

            //assert
            RepositorioCliente.SelecionarPorId(cliente.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_clientes()
        {
            //arrange
            var ricardo = Builder<Cliente>.CreateNew().Persist();
            var maria = Builder<Cliente>.CreateNew().Persist();

            //action
            var clientes = RepositorioCliente.SelecionarTodos();

            //assert
            clientes.Should().ContainInOrder(ricardo, maria);
            clientes.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_cliente_por_nome_e_tipo()
        {
            //arrange
            var ricardo = Builder<Cliente>.CreateNew().Persist();

            //action
            var clienteEncontrado = RepositorioCliente.SelecionarPorNomeETipoDeCliente(ricardo.Nome, ricardo.TipoCliente);

			//assert
			clienteEncontrado.Should().Be(ricardo);
        }

        [TestMethod]
        public void Deve_selecionar_cliente_por_id()
        {
            //arrange
            var ricardo = Builder<Cliente>.CreateNew().Persist();

            //action
            var clienteEncontrado = RepositorioCliente.SelecionarPorId(ricardo.Id);

			//assert            
			clienteEncontrado.Should().Be(ricardo);
        }
    }
}