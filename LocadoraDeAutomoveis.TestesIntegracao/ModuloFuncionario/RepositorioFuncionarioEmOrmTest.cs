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
			ContextoPersistencia.GravarDados();

			//assert
			RepositorioFuncionario.SelecionarPorId(funcionario.Id).Should().Be(funcionario);
        }
        
        [TestMethod]
        public void Deve_editar_funcionario()
        {
            //arrange
            var funcionarioId = Builder<Funcionario>.CreateNew().Persist().Id;

            var funcionario = RepositorioFuncionario.SelecionarPorId(funcionarioId);
            funcionario!.Nome = "João";
            funcionario.DataAdmissao = Convert.ToDateTime("10/02/2022");
            funcionario.Salario = 5;

            //action
            RepositorioFuncionario.Editar(funcionario);
			ContextoPersistencia.GravarDados();

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
			ContextoPersistencia.GravarDados();

			//assert
			RepositorioFuncionario.SelecionarPorId(funcionario.Id).Should().BeNull();
        }
        
        [TestMethod]
        public void Deve_selecionar_todos_funcionarios()
        {
            //arrange
            var joao = Builder<Funcionario>.CreateNew().With(x => x.Nome = "João").Persist();
            var roberto = Builder<Funcionario>.CreateNew().With(x => x.Nome = "Roberto").Persist();

            //action
            var funcionarios = RepositorioFuncionario.SelecionarTodos();

            //assert
            funcionarios.Should().ContainInOrder(joao, roberto);
            funcionarios.Should().HaveCount(2);
        }
        [TestMethod]
        public void Deve_selecionar_funcionario_por_id()
        {
            //arrange
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            //action
            var funcionariosEncontrada = RepositorioFuncionario.SelecionarPorId(funcionario.Id);

            //assert            
            funcionariosEncontrada.Should().Be(funcionario);
        }
    }
}
