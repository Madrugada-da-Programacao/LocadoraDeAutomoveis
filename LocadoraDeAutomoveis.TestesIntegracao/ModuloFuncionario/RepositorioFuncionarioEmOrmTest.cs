using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraDeAutomoveis.TestesIntegracao.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_funcionario()
        {
            //arrange
            var funcionario = Builder<Funcionario>.CreateNew().Build();

            //action
            RepositorioFuncionario.Inserir(funcionario);

            //assert
            RepositorioFuncionario.SelecionarPorId(funcionario.Id).Should().Be(funcionario);
        }
        /*
        [TestMethod]
        public void Deve_editar_funcionario()
        {
            //arrange
            var funcionarioId = Builder<Funcionario>.CreateNew().Persist().Id;

            var funcionario = RepositorioFuncionario.SelecionarPorId(funcionarioId);
            funcionario.Nome = "História";

            //action
            RepositorioFuncionario.Editar(funcionario);

            //assert
            RepositorioFuncionario.SelecionarPorId(funcionario.Id)
                .Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            //arrange
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            //action
            RepositorioFuncionario.Excluir(funcionario);

            //assert
            RepositorioFuncionario.SelecionarPorId(funcionario.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_funcionarios()
        {
            //arrange
            var matematica = Builder<Funcionario>.CreateNew().With(x => x.Nome = "Matemática").Persist();
            var portugues = Builder<Funcionario>.CreateNew().With(x => x.Nome = "Português").Persist();

            //action
            var funcionarios = RepositorioFuncionario.SelecionarTodos();

            //assert
            funcionarios.Should().ContainInOrder(matematica, portugues);
            funcionarios.Should().HaveCount(2);
        }
        /*
        [TestMethod]
        public void Deve_selecionar_funcionarios_com_materias()
        {
            //arrange
            var matematica = Builder<Funcionario>.CreateNew().Persist();

            var adiciaoUnidades = Builder<Materia>.CreateNew().With(x => x.Funcionario = matematica).Persist();
            var adiciaoDezenas = Builder<Materia>.CreateNew().With(x => x.Funcionario = matematica).Persist();

            //action
            var funcionarios = RepositorioFuncionario.SelecionarTodos(incluirMaterias: true);

            //assert
            funcionarios[0].Materias.Should().ContainInOrder(adiciaoUnidades, adiciaoDezenas);
            funcionarios[0].Materias.Count.Should().Be(2);
        }

        [TestMethod]
        public void Deve_selecionar_funcionarios_com_materias_e_questoes()
        {
            //arrange
            var matematica = Builder<Funcionario>.CreateNew().Persist();

            var adiciaoUnidades = Builder<Materia>.CreateNew().With(x => x.Funcionario = matematica).Persist();

            var questao1 = Builder<Questao>.CreateNew().With(x => x.Materia = adiciaoUnidades).Persist();
            var questao2 = Builder<Questao>.CreateNew().With(x => x.Materia = adiciaoUnidades).Persist();

            //action
            var funcionariosEncontradas = RepositorioFuncionario.SelecionarTodos(incluirMaterias: true, incluirQuestoes: true);

            //assert
            funcionariosEncontradas[0].Materias[0].Questoes.Should().ContainInOrder(questao1, questao2);
            funcionariosEncontradas[0].Materias[0].Questoes.Should().HaveCount(2);
        }
        
        [TestMethod]
        public void Deve_selecionar_funcionario_por_nome()
        {
            //arrange
            var matematica = Builder<Funcionario>.CreateNew().Persist();

            //action
            var funcionariosEncontrada = RepositorioFuncionario.SelecionarPorNome(matematica.Nome);

            //assert
            funcionariosEncontrada.Should().Be(matematica);
        }

        [TestMethod]
        public void Deve_selecionar_funcionario_por_id()
        {
            //arrange
            var matematica = Builder<Funcionario>.CreateNew().Persist();

            //action
            var funcionariosEncontrada = RepositorioFuncionario.SelecionarPorId(matematica.Id);

            //assert            
            funcionariosEncontrada.Should().Be(matematica);
        }
        */
    }
}
