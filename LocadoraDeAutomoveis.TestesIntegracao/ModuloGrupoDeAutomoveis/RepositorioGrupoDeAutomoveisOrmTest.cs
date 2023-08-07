using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeAutomoveis.Dominio;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.TestesIntegracao.ModuloGrupoDeAutomoveis
{
    [TestClass]
    public class RepositorioGrupoDeAutomoveisOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Inserir_Grupo_OK()
        {
            var grupo = Builder<GrupoDeAutomoveis>.CreateNew().Build();

            RepositorioGrupoDeAutomoveis.Inserir(grupo);

            RepositorioGrupoDeAutomoveis.SelecionarPorId(grupo.Id).Should().Be(grupo);
        }

        [TestMethod]
        public void Editar_Grupo_OK()
        {
            var grupoId = Builder<GrupoDeAutomoveis>.CreateNew().Persist().Id;
            var grupo = RepositorioGrupoDeAutomoveis.SelecionarPorId(grupoId);
            grupo.Nome = "SUV";

            RepositorioGrupoDeAutomoveis.Editar(grupo);

            RepositorioGrupoDeAutomoveis.SelecionarPorId(grupo.Id).Should().Be(grupo);
        }

        [TestMethod]
        public void Excluir_Grupo_OK()
        {
            var grupo = Builder<GrupoDeAutomoveis>.CreateNew().Persist();

            RepositorioGrupoDeAutomoveis.Excluir(grupo);

            RepositorioGrupoDeAutomoveis.SelecionarPorId(grupo.Id).Should().BeNull();
        }

        [TestMethod]
        public void Selecionar_Todos_OK()
        {
            var PCD = Builder<GrupoDeAutomoveis>.CreateNew().Persist();
            var OffRoad = Builder<GrupoDeAutomoveis>.CreateNew().Persist();

            var Grupos = RepositorioGrupoDeAutomoveis.SelecionarTodos();

            Grupos.Should().ContainInOrder(PCD, OffRoad);

            Grupos.Should().HaveCount(2);
        }

        [TestMethod]
        public void Selecionar_Por_Nome_OK()
        {
            var Esportivo = Builder<GrupoDeAutomoveis>.CreateNew().Persist();

            var grupoEncontrado = RepositorioGrupoDeAutomoveis.SelecionarPorNome(Esportivo.Nome);
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
