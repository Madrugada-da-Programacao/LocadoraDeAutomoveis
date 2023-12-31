﻿using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using Moq;

namespace LocadoraDeAutomoveis.TestesUnitarios.Aplicacao
{
    [TestClass]
    public class ServicoFuncionarioTest
    {
        Mock<IRepositorioFuncionario> repositorioFuncionarioMoq;
        Mock<IValidadorFuncionario> validodorMoq;
		Mock<IContextoPersistencia> ContextoPersistencia { get; set; }

		private ServicoFuncionario servicoFuncionario;

        Funcionario funcionario;

        public ServicoFuncionarioTest()
        {
            repositorioFuncionarioMoq = new Mock<IRepositorioFuncionario>();
            validodorMoq = new Mock<IValidadorFuncionario>();
			ContextoPersistencia = new Mock<IContextoPersistencia>();
			servicoFuncionario = new ServicoFuncionario(repositorioFuncionarioMoq.Object, validodorMoq.Object, ContextoPersistencia.Object);
            funcionario = new Funcionario("João", Convert.ToDateTime("20/02/2022"), 555);
        }

        [TestMethod]
        public void Deve_inserir_funcionario_caso_ele_for_valido() //cenário 1
        {
            //arrange
            funcionario = new Funcionario("João", Convert.ToDateTime("20/02/2022"), 555);

            //action
            Result resultado = servicoFuncionario.Inserir(funcionario);

            //assert 
            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_funcionario_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            validodorMoq.Setup(x => x.Validate(It.IsAny<Funcionario>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoFuncionario.Inserir(funcionario);

            //assert             
            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_funcionario_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeFuncionario = "João";
            repositorioFuncionarioMoq.Setup(x => x.SelecionarPorNome(nomeFuncionario))
                .Returns(() =>
                {
                    return new Funcionario(Guid.NewGuid(), nomeFuncionario, Convert.ToDateTime("20/02/2022"), 555);
                });

            //action
            var resultado = servicoFuncionario.Inserir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeFuncionario}' já está sendo utilizado");
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_funcionario() //cenário 4
        {
            repositorioFuncionarioMoq.Setup(x => x.Inserir(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoFuncionario.Inserir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir funcionario.");
        }


        [TestMethod]
        public void Deve_editar_funcionario_caso_ele_for_valido() //cenário 1
        {
            //arrange           
            funcionario = new Funcionario(Guid.NewGuid(), "João", Convert.ToDateTime("20/02/2022"), 555);

            //action
            Result resultado = servicoFuncionario.Editar(funcionario);

            //assert 
            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Editar(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_funcionario_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            validodorMoq.Setup(x => x.Validate(It.IsAny<Funcionario>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoFuncionario.Editar(funcionario);

            //assert             
            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Editar(funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_funcionario_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Guid id = Guid.NewGuid();

            repositorioFuncionarioMoq.Setup(x => x.SelecionarPorNome("João"))
                 .Returns(() =>
                 {
                     return new Funcionario(id, "João", Convert.ToDateTime("20/02/2022"), 555);
                 });

            Funcionario outroFuncionario = new Funcionario(id, "João", Convert.ToDateTime("20/02/2022"), 555);

            //action
            var resultado = servicoFuncionario.Editar(outroFuncionario);

            //assert 
            resultado.Should().BeSuccess();

            repositorioFuncionarioMoq.Verify(x => x.Editar(outroFuncionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_funcionario_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            repositorioFuncionarioMoq.Setup(x => x.SelecionarPorNome("João"))
                 .Returns(() =>
                 {
                     return new Funcionario(Guid.NewGuid(), "João", Convert.ToDateTime("20/02/2022"), 555);
                 });

            Funcionario novaFuncionario = new Funcionario("João", Convert.ToDateTime("20/02/2022"), 555);

            //action
            var resultado = servicoFuncionario.Editar(novaFuncionario);

            //assert 
            resultado.Should().BeFailure();

            repositorioFuncionarioMoq.Verify(x => x.Editar(novaFuncionario), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_funcionario() //cenário 5
        {
            repositorioFuncionarioMoq.Setup(x => x.Editar(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoFuncionario.Editar(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar funcionario.");
        }


        [TestMethod]
        public void Deve_excluir_funcionario_caso_ele_esteja_cadastrada() //cenário 1
        {
            //arrange
            var funcionario = new Funcionario(Guid.NewGuid(), "João", Convert.ToDateTime("20/02/2022"), 555);

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoFuncionario.Excluir(funcionario);

            //assert 
            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Excluir(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_funcionario_caso_ele_nao_esteja_cadastrada() //cenário 2
        {
            //arrange

            var funcionario = new Funcionario(Guid.NewGuid(), "João", Convert.ToDateTime("20/02/2022"), 555);

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoFuncionario.Excluir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Excluir(funcionario), Times.Never());
        }
        /*TODO 
                [TestMethod]
                public void Nao_deve_excluir_funcionario_caso_ele_esteja_relacionada_com_materia() //cenário 3
                {
                    var funcionario = new Funcionario(Guid.NewGuid(), "Matemática");

                    repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
                       .Returns(() =>
                       {
                           return true;
                       });

                    // como configurar um método para ele lançar uma sqlexception utilizando moq

                    repositorioFuncionarioMoq.Setup(x => x.Excluir(It.IsAny<Funcionario>()))
                        .Throws(() =>
                        {
                            /** Solução utilizando Chat GPT
                               *  var exception = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));
                               *  
                               *  FieldInfo messageField = typeof(SqlException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic);
                               *  if (messageField != null)
                               *  {
                               *      messageField.SetValue(exception, "Esta é uma mensagem personalizada para a exceção SQL.");
                               *  }
                               *//*

                            return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBMateria_TBFuncionario");
                        });

                    //action
                    Result resultado = servicoFuncionario.Excluir(funcionario);

                    //assert 
                    resultado.Should().BeFailure();
                    resultado.Reasons[0].Message.Should().Be("Esta funcionario está relacionada com uma matéria e não pode ser excluída");
                }
        */
        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_funcionario() //cenário 4
        {
            var funcionario = new Funcionario(Guid.NewGuid(), "João", Convert.ToDateTime("20/02/2022"), 555);

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoFuncionario.Excluir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir funcionario");
        }

    }
}
