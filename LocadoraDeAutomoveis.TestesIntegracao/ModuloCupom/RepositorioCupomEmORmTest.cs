using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeAutomoveis.Dominio.ModuloCupom;

namespace LocadoraDeAutomoveis.TestesIntegracao.ModuloCupom
{
	[TestClass]
	public class RepositorioCupomEmORmTest : TestesIntegracaoBase
	{
		[TestMethod]
		public void Deve_inserir_cupom()
		{
			//arrange
			var cupom = Builder<Cupom>.CreateNew().Build();

			//action
			RepositorioCupom.Inserir(cupom);
			ContextoPersistencia.GravarDados();

			//assert
			RepositorioCupom.SelecionarPorId(cupom.Id).Should().Be(cupom);
		}

		[TestMethod]
		public void Deve_editar_cupom()
		{
			//arrange
			var cupomId = Builder<Cupom>.CreateNew().Persist().Id;

			var cupom = RepositorioCupom.SelecionarPorId(cupomId);
			cupom!.Nome = "Desconto de Ano Novo";

			//action
			RepositorioCupom.Editar(cupom);
			ContextoPersistencia.GravarDados();

			//assert
			RepositorioCupom.SelecionarPorId(cupom.Id)
				.Should().Be(cupom);
		}

		[TestMethod]
		public void Deve_excluir_cupom()
		{
			//arrange
			var cupom = Builder<Cupom>.CreateNew().Persist();

			//action
			RepositorioCupom.Excluir(cupom);
			ContextoPersistencia.GravarDados();

			//assert
			RepositorioCupom.SelecionarPorId(cupom.Id).Should().BeNull();
		}

		[TestMethod]
		public void Deve_selecionar_todos_cupons()
		{
			//arrange
			var descontoNatal = Builder<Cupom>.CreateNew().Persist();
			var descontoAnoNovo = Builder<Cupom>.CreateNew().Persist();

			//action
			var cupons = RepositorioCupom.SelecionarTodos();

			//assert
			cupons.Should().ContainInOrder(descontoNatal, descontoAnoNovo);
			cupons.Should().HaveCount(2);
		}

		[TestMethod]
		public void Deve_selecionar_cupom_por_nome()
		{
			//arrange
			var descontoNatal = Builder<Cupom>.CreateNew().Persist();

			//action
			var cupomEncontrado = RepositorioCupom.SelecionarPorNome(descontoNatal.Nome);

			//assert
			cupomEncontrado.Should().Be(descontoNatal);
		}

		[TestMethod]
		public void Deve_selecionar_cupom_por_id()
		{
			//arrange
			var descontoNatal = Builder<Cupom>.CreateNew().Persist();

			//action
			var cupomEncontrado = RepositorioCupom.SelecionarPorId(descontoNatal.Id);

			//assert
			cupomEncontrado.Should().Be(descontoNatal);
		}
	}
}
