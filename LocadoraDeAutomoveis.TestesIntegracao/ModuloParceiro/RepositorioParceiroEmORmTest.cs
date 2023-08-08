using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraDeAutomoveis.TestesIntegracao.ModuloParceiro
{
	public class RepositorioParceiroEmORmTest : TestesIntegracaoBase
	{
		[TestMethod]
		public void Deve_inserir_parceiro()
		{
			//arrange
			var parceiro = Builder<Parceiro>.CreateNew().Build();

			//action
			RepositorioParceiro.Inserir(parceiro);

			//assert
			RepositorioParceiro.SelecionarPorId(parceiro.Id).Should().Be(parceiro);
		}

		[TestMethod]
		public void Deve_editar_cliente()
		{
			//arrange
			var parceiroId = Builder<Parceiro>.CreateNew().Persist().Id;

			var parceiro = RepositorioParceiro.SelecionarPorId(parceiroId);
			parceiro!.Nome = "Americanas";

			//action
			RepositorioParceiro.Editar(parceiro);

			//assert
			RepositorioParceiro.SelecionarPorId(parceiro.Id)
				.Should().Be(parceiro);
		}

		[TestMethod]
		public void Deve_excluir_parceiro()
		{
			//arrange
			var parceiro = Builder<Parceiro>.CreateNew().Persist();

			//action
			RepositorioParceiro.Excluir(parceiro);

			//assert
			RepositorioParceiro.SelecionarPorId(parceiro.Id).Should().BeNull();
		}

		[TestMethod]
		public void Deve_selecionar_todos_parceiros()
		{
			//arrange
			var americanas = Builder<Parceiro>.CreateNew().Persist();
			var havam = Builder<Parceiro>.CreateNew().Persist();

			//action
			var parceiros = RepositorioParceiro.SelecionarTodos();

			//assert
			parceiros.Should().ContainInOrder(americanas, havam);
			parceiros.Should().HaveCount(2);
		}

		[TestMethod]
		public void Deve_selecionar_parceiro_por_nome()
		{
			//arrange
			var americanas = Builder<Parceiro>.CreateNew().Persist();

			//action
			var parceiroEncontrado = RepositorioParceiro.SelecionarPorNome(americanas.Nome);

			//assert
			parceiroEncontrado.Should().Be(americanas);
		}

		[TestMethod]
		public void Deve_selecionar_parceiro_por_id()
		{
			//arrange
			var americanas = Builder<Parceiro>.CreateNew().Persist();

			//action
			var parceiroEncontrado = RepositorioParceiro.SelecionarPorId(americanas.Id);

			//assert            
			parceiroEncontrado.Should().Be(americanas);
		}
	}
}
