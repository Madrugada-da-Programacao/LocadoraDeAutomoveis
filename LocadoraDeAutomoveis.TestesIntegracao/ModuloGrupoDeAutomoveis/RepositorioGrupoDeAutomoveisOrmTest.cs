using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;

namespace LocadoraDeAutomoveis.TestesIntegracao.ModuloGrupoDeAutomoveis
{
    [TestClass]
    public class RepositorioGrupoDeAutomoveisOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Inserir_Grupo()
        {
			//arrange
			var grupo = Builder<GrupoDeAutomoveis>.CreateNew().Build();

			//action
			RepositorioGrupoDeAutomoveis.Inserir(grupo);
			ContextoPersistencia.GravarDados();

			//assert
			RepositorioGrupoDeAutomoveis.SelecionarPorId(grupo.Id).Should().Be(grupo);
        }

        [TestMethod]
        public void Editar_Grupo_OK()
        {
			//arrange
			var grupoId = Builder<GrupoDeAutomoveis>.CreateNew().Persist().Id;
            var grupo = RepositorioGrupoDeAutomoveis.SelecionarPorId(grupoId);
            grupo!.Nome = "SUV";

			//action
			RepositorioGrupoDeAutomoveis.Editar(grupo);
			ContextoPersistencia.GravarDados();

			//assert
			RepositorioGrupoDeAutomoveis.SelecionarPorId(grupo.Id).Should().Be(grupo);
        }

        [TestMethod]
        public void Excluir_Grupo_OK()
        {
			//arrange
			var grupo = Builder<GrupoDeAutomoveis>.CreateNew().Persist();

			//action
			RepositorioGrupoDeAutomoveis.Excluir(grupo);
			ContextoPersistencia.GravarDados();

			//assert
			RepositorioGrupoDeAutomoveis.SelecionarPorId(grupo.Id).Should().BeNull();
        }

        [TestMethod]
        public void Selecionar_Todos_OK()
        {
			//arrange
			var PCD = Builder<GrupoDeAutomoveis>.CreateNew().Persist();
            var OffRoad = Builder<GrupoDeAutomoveis>.CreateNew().Persist();

			//action
			var Grupos = RepositorioGrupoDeAutomoveis.SelecionarTodos();

			//assert
			Grupos.Should().ContainInOrder(PCD, OffRoad);
            Grupos.Should().HaveCount(2);
        }

        [TestMethod]
        public void Selecionar_Por_Nome_OK()
        {
			//arrange
			var Esportivo = Builder<GrupoDeAutomoveis>.CreateNew().Persist();

			//action
			var grupoEncontrado = RepositorioGrupoDeAutomoveis.SelecionarPorNome(Esportivo.Nome);

			//assert
			grupoEncontrado.Should().Be(Esportivo);
        }

        [TestMethod]
        public void Selecionar_Por_ID_OK()
        {
            //arrange
            var SUV = Builder<GrupoDeAutomoveis>.CreateNew().Persist();

            //action
            var grupoEncontrado = RepositorioGrupoDeAutomoveis.SelecionarPorId(SUV.Id);

            //assert            
            grupoEncontrado.Should().Be(SUV);
        }
    }
}
