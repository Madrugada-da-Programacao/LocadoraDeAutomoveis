using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.TestesIntegracao.ModuloAutomovel
{
	[TestClass]
	public class RepositorioAutomovelEmORmTest : TestesIntegracaoBase
	{
		[TestMethod]
		public void Deve_inserir_automovel()
		{
			//arrange
			var grupoDeAutomoveis = Builder<GrupoDeAutomoveis>.CreateNew().Build();
			var automovel = Builder<Automovel>.CreateNew()
								   .With(a => a.GrupoDeAutomovel, grupoDeAutomoveis)
								   .Build();

			//action
			RepositorioAutomovel.Inserir(automovel);
			ContextoPersistencia.GravarDados();

			//assert
			RepositorioAutomovel.SelecionarPorId(automovel.Id).Should().Be(automovel);
		}

		[TestMethod]
		public void Deve_editar_automovel()
		{
			//arrange
			var grupoDeAutomoveis = Builder<GrupoDeAutomoveis>.CreateNew().Build();

			var automovelId = Builder<Automovel>.CreateNew().With(a => a.GrupoDeAutomovel, grupoDeAutomoveis).Persist().Id;

			var automovel = RepositorioAutomovel.SelecionarPorId(automovelId);
			automovel!.Cor = "Branco";

			//action
			RepositorioAutomovel.Editar(automovel);
			ContextoPersistencia.GravarDados();

			//assert
			RepositorioAutomovel.SelecionarPorId(automovel.Id)
				.Should().Be(automovel);
		}

		[TestMethod]
		public void Deve_excluir_automovel()
		{
			//arrange
			var grupoDeAutomoveis = Builder<GrupoDeAutomoveis>.CreateNew().Build();
			var automovel = Builder<Automovel>.CreateNew()
								   .With(a => a.GrupoDeAutomovel, grupoDeAutomoveis)
								   .Persist();

			//action
			RepositorioAutomovel.Excluir(automovel);
			ContextoPersistencia.GravarDados();

			//assert
			RepositorioAutomovel.SelecionarPorId(automovel.Id).Should().BeNull();
		}

		[TestMethod]
		public void Deve_selecionar_todos_automoveis()
		{
			//arrange
			var grupo1 = Builder<GrupoDeAutomoveis>.CreateNew().Build();
			var automovel1 = Builder<Automovel>.CreateNew()
								   .With(a => a.GrupoDeAutomovel, grupo1)
								   .Persist();
			var grupo2 = Builder<GrupoDeAutomoveis>.CreateNew().Build();
			var automovel2 = Builder<Automovel>.CreateNew()
								   .With(a => a.GrupoDeAutomovel, grupo2)
								   .Persist();

			//action
			var automoveis = RepositorioAutomovel.SelecionarTodos();

			//assert
			automoveis.Should().ContainInOrder(automovel1, automovel2);
			automoveis.Should().HaveCount(2);
		}

		[TestMethod]
		public void Deve_selecionar_automovel_por_id()
		{
			//arrange
			var grupoDeAutomoveis = Builder<GrupoDeAutomoveis>.CreateNew().Build();
			var automovel = Builder<Automovel>.CreateNew()
								   .With(a => a.GrupoDeAutomovel, grupoDeAutomoveis)
								   .Persist();

			//action
			var automovelEncontrado = RepositorioAutomovel.SelecionarPorId(automovel.Id);

			//assert            
			automovelEncontrado.Should().Be(automovel);
		}

		[TestMethod]
		public void Deve_selecionar_automovel_por_placa()
		{
			//arrange
			var grupoDeAutomoveis = Builder<GrupoDeAutomoveis>.CreateNew().Build();
			var automovel = Builder<Automovel>.CreateNew()
								   .With(a => a.GrupoDeAutomovel, grupoDeAutomoveis)
								   .With(a => a.Placa, "AAA-4444")
								   .Persist();

			//action
			var automovelEncontrado = RepositorioAutomovel.SelecionarPorPlaca("AAA-4444");

			//assert            
			automovelEncontrado.Should().Be(automovel);
		}

		[TestMethod]
		public void Deve_selecionar_automovel_por_grupo()
		{
			//arrange
			var grupo = Builder<GrupoDeAutomoveis>.CreateNew().Build();
			var automovel1 = Builder<Automovel>.CreateNew()
								   .With(a => a.GrupoDeAutomovel, grupo)
								   .Persist();
			var automovel2 = Builder<Automovel>.CreateNew()
								   .With(a => a.GrupoDeAutomovel, grupo)
								   .Persist();

			//action
			var automoveis = RepositorioAutomovel.SelecionarPorGrupo(grupo);

			//assert
			automoveis.Should().ContainInOrder(automovel1, automovel2);
			automoveis.Should().HaveCount(2);
		}

		[TestMethod]
		public void Deve_selecionar_todos_automoveis_com_grupo_de_automovel()
		{
			//arrange
			var grupo1 = Builder<GrupoDeAutomoveis>.CreateNew().Build();
			var automovel1 = Builder<Automovel>.CreateNew()
								   .With(a => a.GrupoDeAutomovel, grupo1)
								   .Persist();
			var grupo2 = Builder<GrupoDeAutomoveis>.CreateNew().Build();
			var automovel2 = Builder<Automovel>.CreateNew()
								   .With(a => a.GrupoDeAutomovel, grupo2)
								   .Persist();

			//action
			var automoveis = RepositorioAutomovel.SelecionarTodosComGrupoDeAutomovel();

			//assert
			automoveis.Should().ContainInOrder(automovel1, automovel2);
			automoveis.Should().HaveCount(2);
		}

	}
}
