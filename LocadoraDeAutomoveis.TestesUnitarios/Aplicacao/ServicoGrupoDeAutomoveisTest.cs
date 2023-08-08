using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using Moq;

namespace LocadoraDeAutomoveis.TestesUnitarios.Aplicacao
{
    [TestClass]
    public class ServicoGrupoDeAutomoveisTest
    {
        Mock<IRepositorioGrupoDeAutomoveis> RepositorioGrupoDeAutomoveisMock { get; set; }
        Mock<IValidadorGrupoDeAutomoveis> ValidadorGrupoDeAutomoveisMock { get; set; }

        private ServicoGrupoDeAutomoveis ServicoGrupoDeAutomoveis { get; set; }
        GrupoDeAutomoveis GrupoDeAutomoveis { get; set; }

        public ServicoGrupoDeAutomoveisTest()
        {
            RepositorioGrupoDeAutomoveisMock = new Mock<IRepositorioGrupoDeAutomoveis>();
            ValidadorGrupoDeAutomoveisMock = new Mock<IValidadorGrupoDeAutomoveis>();
            ServicoGrupoDeAutomoveis = new ServicoGrupoDeAutomoveis(RepositorioGrupoDeAutomoveisMock.Object, ValidadorGrupoDeAutomoveisMock.Object);

            GrupoDeAutomoveis = new GrupoDeAutomoveis("SUV");
        }

        [TestMethod]
        public void Inserir_Se_Nome_OK()
        {
            GrupoDeAutomoveis = new GrupoDeAutomoveis("PCD");
            Result resultado = ServicoGrupoDeAutomoveis.Inserir(GrupoDeAutomoveis);

            resultado.Should().BeSuccess();
            RepositorioGrupoDeAutomoveisMock.Verify(x => x.Inserir(GrupoDeAutomoveis), Times.Once());
        }
        [TestMethod]
        public void Nao_Inserir_Nome_Nulo()
        {
            ValidadorGrupoDeAutomoveisMock.Setup(x => x.Validate(It.IsAny<GrupoDeAutomoveis>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ser nulo"));
                return resultado;
            });

            var resultado = ServicoGrupoDeAutomoveis.Inserir(GrupoDeAutomoveis);

            resultado.Should().BeFailure();
            RepositorioGrupoDeAutomoveisMock.Verify(x => x.Inserir(GrupoDeAutomoveis), Times.Never);
        }
        [TestMethod]
        public void Tratar_Erro_Caso_Falha_Inserir()
        {
            RepositorioGrupoDeAutomoveisMock.Setup(x => x.Inserir(It.IsAny<GrupoDeAutomoveis>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = ServicoGrupoDeAutomoveis.Inserir(GrupoDeAutomoveis);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir grupo de automoveis.");
        }
        [TestMethod]
        public void Editar_OK()
        {
            GrupoDeAutomoveis = new GrupoDeAutomoveis("SUV");
            Result resultado = ServicoGrupoDeAutomoveis.Editar(GrupoDeAutomoveis);

            resultado.Should().BeSuccess();
            RepositorioGrupoDeAutomoveisMock.Verify(x => x.Editar(GrupoDeAutomoveis), Times.Once());
        }
        [TestMethod]
        public void Nao_Editar_Nome_Nulo()
        {
            ValidadorGrupoDeAutomoveisMock.Setup(x => x.Validate(It.IsAny<GrupoDeAutomoveis>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ser nulo"));
                return resultado;
            });

            var resultado = ServicoGrupoDeAutomoveis.Editar(GrupoDeAutomoveis);

            resultado.Should().BeFailure();
            RepositorioGrupoDeAutomoveisMock.Verify(x => x.Editar(GrupoDeAutomoveis), Times.Never());
        }
        [TestMethod]
        public void Tratar_Erro_Caso_Falha_Editar()
        {
            RepositorioGrupoDeAutomoveisMock.Setup(x => x.Editar(It.IsAny<GrupoDeAutomoveis>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = ServicoGrupoDeAutomoveis.Editar(GrupoDeAutomoveis);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar editar Grupo de Automoveis.");
        }
        [TestMethod]
        public void Nao_Inserir_Nome_Repetido()
        {
            string grupo = "SUV";
            RepositorioGrupoDeAutomoveisMock.Setup(x => x.SelecionarPorNome(grupo)).Returns(() =>
            {
                return new GrupoDeAutomoveis(grupo);
            });

            var resultado = ServicoGrupoDeAutomoveis.Inserir(GrupoDeAutomoveis);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{grupo}' já está sendo utilizado");
        }
        [TestMethod]
        public void Nao_Editar_Nome_Repetido()
        {
            string grupo = "SUV";
            RepositorioGrupoDeAutomoveisMock.Setup(x => x.SelecionarPorNome(grupo)).Returns(() =>
            {
                return new GrupoDeAutomoveis(grupo);
            });

            var resultado = ServicoGrupoDeAutomoveis.Editar(GrupoDeAutomoveis);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{grupo}' já está sendo utilizado");
        }
        [TestMethod]
        public void Excluir_OK()
        {
            var grupo = new GrupoDeAutomoveis("Off-Road");
            RepositorioGrupoDeAutomoveisMock.Setup(x => x.Existe(grupo)).Returns(true);

            var resultado = ServicoGrupoDeAutomoveis.Excluir(grupo);
            resultado.Should().BeSuccess();
            RepositorioGrupoDeAutomoveisMock.Verify(x => x.Existe(grupo), Times.Once());
        }
        [TestMethod]
        public void Excluir_Falha()
        {
            var grupo = new GrupoDeAutomoveis("Off-Road");

            RepositorioGrupoDeAutomoveisMock.Setup(x => x.Existe(grupo))
                .Returns(() =>
            {
                return false;
            });

            var resultado = ServicoGrupoDeAutomoveis.Excluir(grupo);
            resultado.Should().BeFailure();
            RepositorioGrupoDeAutomoveisMock.Verify(x => x.Excluir(grupo), Times.Never());
        }
        //TODO
        //Implementar Teste de falha ao tentar excluir com modulo sendo utilizado
        [TestMethod]
        public void Excluir_Tratar_Falha()
        {
            var grupo = new GrupoDeAutomoveis("Off-Road");
            RepositorioGrupoDeAutomoveisMock.Setup(x => x.Existe(grupo)).Throws(() =>
            {
                return SqlExceptionCreator.NewSqlException();
            });

            var resultado = ServicoGrupoDeAutomoveis.Excluir(grupo);
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir Grupo de Automoveis");
        }
    }
}
