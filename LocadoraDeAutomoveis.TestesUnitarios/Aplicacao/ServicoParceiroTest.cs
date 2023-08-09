using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeAutomoveis.Aplicacao.ModuloParceiro;
using LocadoraDeAutomoveis.Dominio.ModuloParceiro;
using Moq;

namespace LocadoraDeAutomoveis.TestesUnitarios.Aplicacao
{
    [TestClass]
    public class ServicoParceiroTest
    {
        Mock<IRepositorioParceiro> RepositorioParceiroMoq { get; set; }
        Mock<IValidadorParceiro> ValidadorParceiroMoq { get; set; }
		Mock<IContextoPersistencia> ContextoPersistencia { get; set; }
		private ServicoParceiro ServicoParceiro { get; set; }
        private Parceiro Parceiro { get; set; }

        public ServicoParceiroTest()
        {
            RepositorioParceiroMoq = new Mock<IRepositorioParceiro>();
            ValidadorParceiroMoq = new Mock<IValidadorParceiro>();
			ContextoPersistencia = new Mock<IContextoPersistencia>();
			ServicoParceiro = new ServicoParceiro(RepositorioParceiroMoq.Object, ValidadorParceiroMoq.Object, ContextoPersistencia.Object);
            Parceiro = new Parceiro("Americanas");
        }

        [TestMethod]
        public void Deve_inserir_parceiro_caso_ele_for_valido() //cenário 1
        {
            //arrange
            Parceiro = new Parceiro("Americanas");

            //action
            Result resultado = ServicoParceiro.Inserir(Parceiro);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioParceiroMoq.Verify(x => x.Inserir(Parceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_parceiro_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            ValidadorParceiroMoq.Setup(x => x.Validate(It.IsAny<Parceiro>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = ServicoParceiro.Inserir(Parceiro);

            //assert             
            resultado.Should().BeFailure();
            RepositorioParceiroMoq.Verify(x => x.Inserir(Parceiro), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_parceiro_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeParceiro = "Americanas";

            RepositorioParceiroMoq.Setup(x => x.SelecionarPorNome(nomeParceiro))
                .Returns(() =>
                {
                    return new Parceiro(nomeParceiro);
                });

            //action
            var resultado = ServicoParceiro.Inserir(Parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeParceiro}' já está sendo utilizado");
            RepositorioParceiroMoq.Verify(x => x.Inserir(Parceiro), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_parceiro() //cenário 4
        {
            RepositorioParceiroMoq.Setup(x => x.Inserir(It.IsAny<Parceiro>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = ServicoParceiro.Inserir(Parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir parceiro.");
        }

        [TestMethod]
        public void Deve_editar_cliente_caso_ele_for_valido() //cenário 1
        {
            //arrange           
            Parceiro = new Parceiro("Americanas");

            //action
            Result resultado = ServicoParceiro.Editar(Parceiro);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioParceiroMoq.Verify(x => x.Editar(Parceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_parceiro_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            ValidadorParceiroMoq.Setup(x => x.Validate(It.IsAny<Parceiro>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = ServicoParceiro.Editar(Parceiro);

            //assert             
            resultado.Should().BeFailure();
            RepositorioParceiroMoq.Verify(x => x.Editar(Parceiro), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_parceiro_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Guid id = Guid.NewGuid();
            string nomeParceiro = "Americanas";

            RepositorioParceiroMoq.Setup(x => x.SelecionarPorNome(nomeParceiro))
                 .Returns(() =>
                 {
                     return new Parceiro(id
                                      , nomeParceiro);
                 });

            Parceiro outroParceiro = new Parceiro(id
                                                , nomeParceiro);

            //action
            var resultado = ServicoParceiro.Editar(outroParceiro);

            //assert 
            resultado.Should().BeSuccess();

            RepositorioParceiroMoq.Verify(x => x.Editar(outroParceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_parceiro_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeParceiro = "Americanas";

            RepositorioParceiroMoq.Setup(x => x.SelecionarPorNome(nomeParceiro))
                 .Returns(() =>
                 {
                     return new Parceiro(nomeParceiro);
                 });

            Parceiro novoParceiro = new Parceiro(nomeParceiro);

            //action
            var resultado = ServicoParceiro.Editar(novoParceiro);

            //assert 
            resultado.Should().BeFailure();

            RepositorioParceiroMoq.Verify(x => x.Editar(novoParceiro), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_parceiro() //cenário 5
        {
            RepositorioParceiroMoq.Setup(x => x.Editar(It.IsAny<Parceiro>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = ServicoParceiro.Editar(Parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar parceiro.");
        }

        [TestMethod]
        public void Deve_excluir_parceiro_caso_ele_esteja_cadastrada() //cenário 1
        {
            //arrange
            var parceiro = new Parceiro("Americanas");

            RepositorioParceiroMoq.Setup(x => x.Existe(parceiro))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = ServicoParceiro.Excluir(parceiro);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioParceiroMoq.Verify(x => x.Excluir(parceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_parceiro_caso_ele_nao_esteja_cadastrada() //cenário 2
        {
            //arrange

            var parceiro = new Parceiro("Americanas");

            RepositorioParceiroMoq.Setup(x => x.Existe(parceiro))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = ServicoParceiro.Excluir(parceiro);

            //assert 
            resultado.Should().BeFailure();
            RepositorioParceiroMoq.Verify(x => x.Excluir(parceiro), Times.Never());
        }

        //TODO verificar quando o modulo que dependa deste modo estiver pronto implementar esse teste
        //[TestMethod]
        //public void Nao_deve_excluir_disciplina_caso_ela_esteja_relacionada_com_materia() //cenário 3
        //{            
        //    var disciplina = new Disciplina("Matemática");

        //    RepositorioClienteMoq.Setup(x => x.Existe(disciplina))
        //       .Returns(() =>
        //       {
        //           return true;
        //       });

        //    // como configurar um método para ele lançar uma sqlexception utilizando moq

        //    RepositorioClienteMoq.Setup(x => x.Excluir(It.IsAny<Disciplina>()))
        //        .Throws(() =>
        //        {
        //            /** Solução utilizando Chat GPT
        //               *  var exception = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));
        //               *  
        //               *  FieldInfo messageField = typeof(SqlException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic);
        //               *  if (messageField != null)
        //               *  {
        //               *      messageField.SetValue(exception, "Esta é uma mensagem personalizada para a exceção SQL.");
        //               *  }
        //               */

        //            return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBMateria_TBDisciplina");
        //        });

        //    //action
        //    Result resultado = ServicoCliente.Excluir(disciplina);

        //    //assert 
        //    resultado.Should().BeFailure();
        //    resultado.Reasons[0].Message.Should().Be("Esta disciplina está relacionada com uma matéria e não pode ser excluída");
        //}

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_parceiro() //cenário 4
        {
            var parceiro = new Parceiro("Americanas");

            RepositorioParceiroMoq.Setup(x => x.Existe(parceiro))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = ServicoParceiro.Excluir(parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir parceiro");
        }
    }
}
