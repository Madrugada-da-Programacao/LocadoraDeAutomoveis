using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using Moq;

namespace LocadoraDeAutomoveis.TestesUnitarios.Aplicacao
{
    [TestClass]
    public class ServicoCondutorTest
    {
        Mock<IRepositorioCondutor> RepositorioCondutorMoq { get; set; }
        Mock<IValidadorCondutor> ValidadorCondutorMoq { get; set; }
        Mock<IContextoPersistencia> ContextoPersistencia { get; set; }
        private ServicoCondutor ServicoCondutor { get; set; }
        Condutor Condutor { get; set; }
        Cliente Cliente { get; set; }

        public ServicoCondutorTest()
        {
            RepositorioCondutorMoq = new Mock<IRepositorioCondutor>();
            ValidadorCondutorMoq = new Mock<IValidadorCondutor>();
            ContextoPersistencia = new Mock<IContextoPersistencia>();
            ServicoCondutor = new ServicoCondutor(RepositorioCondutorMoq.Object, ValidadorCondutorMoq.Object, ContextoPersistencia.Object);
            Cliente = new Cliente("Junior"
                                 , Cliente.TipoDeCliente.PessoaFisica
                                 , "000.000.000-00"
                                 , "exemplo@exemplo.exemplo"
                                 , "(00) 0 0000-0000"
                                 , "SC"
                                 , "Lages"
                                 , "Centro"
                                 , "Frei Gabriel"
                                 , 1);

            Condutor = new Condutor(Cliente 
                                   , false
                                   , "Junior"
                                   , "exemplo@exemplo.exemplo"
                                   , "(00) 0 0000-0000"
                                   , "555.555.555-55"
                                   , "000000000000"
                                   , Convert.ToDateTime("05/02/2022"));
        }

        [TestMethod]
        public void Deve_inserir_condutor_caso_ele_for_valido() //cenário 1
        {
            //arrange
            Condutor = new Condutor(Cliente
                                   , false
                                   , "Junior"
                                   , "exemplo@exemplo.exemplo"
                                   , "(00) 0 0000-0000"
                                   , "555.555.555-55"
                                   , "000000000000"
                                   , Convert.ToDateTime("05/02/2022"));

            //action
            Result resultado = ServicoCondutor.Inserir(Condutor);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioCondutorMoq.Verify(x => x.Inserir(Condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_Condutor_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            ValidadorCondutorMoq.Setup(x => x.Validate(It.IsAny<Condutor>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = ServicoCondutor.Inserir(Condutor);

            //assert             
            resultado.Should().BeFailure();
            RepositorioCondutorMoq.Verify(x => x.Inserir(Condutor), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_Condutor_caso_o_nome_ja_esteja_cadastrado() //cenário 3.1
        {
            //arrange
            string nomeCondutor = "Junior";

            RepositorioCondutorMoq.Setup(x => x.SelecionarPorNome(nomeCondutor))
                .Returns(() =>
                {
                    return new Condutor(Cliente
                                   , false
                                   , nomeCondutor
                                   , "exemplo@exemplo.exemplo"
                                   , "(00) 0 0000-0000"
                                   , "555.555.555-55"
                                   , "000000000000"
                                   , Convert.ToDateTime("05/02/2022"));
                });

            //action
            var resultado = ServicoCondutor.Inserir(Condutor);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeCondutor}' já está sendo utilizado");
            RepositorioCondutorMoq.Verify(x => x.Inserir(Condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_Condutor() //cenário 4
        {
            RepositorioCondutorMoq.Setup(x => x.Inserir(It.IsAny<Condutor>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = ServicoCondutor.Inserir(Condutor);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir condutor.");
        }


        [TestMethod]
        public void Deve_editar_Condutor_caso_ele_for_valido() //cenário 1
        {
            //arrange
            Condutor = new Condutor(Cliente
                                   , false
                                   , "Junior"
                                   , "exemplo@exemplo.exemplo"
                                   , "(00) 0 0000-0000"
                                   , "555.555.555-55"
                                   , "000000000000"
                                   , Convert.ToDateTime("05/02/2022"));

            //action
            Result resultado = ServicoCondutor.Editar(Condutor);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioCondutorMoq.Verify(x => x.Editar(Condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_Condutor_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            ValidadorCondutorMoq.Setup(x => x.Validate(It.IsAny<Condutor>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = ServicoCondutor.Editar(Condutor);

            //assert             
            resultado.Should().BeFailure();
            RepositorioCondutorMoq.Verify(x => x.Editar(Condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_Condutor_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Guid id = Guid.NewGuid();
            string nomeCondutor = "Junior";

            RepositorioCondutorMoq.Setup(x => x.SelecionarPorNome(nomeCondutor))
                 .Returns(() =>
                 {
                     return new Condutor(id
                                        , Cliente
                                        , false
                                        , nomeCondutor
                                        , "exemplo@exemplo.exemplo"
                                        , "(00) 0 0000-0000"
                                        , "555.555.555-55"
                                        , "000000000000"
                                        , Convert.ToDateTime("05/02/2022"));
                 });

            Condutor outroCondutor = new Condutor(id
                                                , Cliente
                                                , false
                                                , nomeCondutor
                                                , "exemplo@exemplo.exemplo"
                                                , "(00) 0 0000-0000"
                                                , "555.555.555-55"
                                                , "000000000000"
                                                , Convert.ToDateTime("05/02/2022"));

            //action
            var resultado = ServicoCondutor.Editar(outroCondutor);

            //assert 
            resultado.Should().BeSuccess();

            RepositorioCondutorMoq.Verify(x => x.Editar(outroCondutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_Condutor_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            string nomeCondutor = "Junior";

            RepositorioCondutorMoq.Setup(x => x.SelecionarPorNome(nomeCondutor))
                 .Returns(() =>
                 {
                     return new Condutor(Cliente
                                   , false
                                   , nomeCondutor
                                   , "exemplo@exemplo.exemplo"
                                   , "(00) 0 0000-0000"
                                   , "555.555.555-55"
                                   , "000000000000"
                                   , Convert.ToDateTime("05/02/2022"));
                 });

            Condutor novoCondutor = new Condutor(Cliente
                                   , false
                                   , nomeCondutor
                                   , "exemplo@exemplo.exemplo"
                                   , "(00) 0 0000-0000"
                                   , "555.555.555-55"
                                   , "000000000000"
                                   , Convert.ToDateTime("05/02/2022")); ;

            //action
            var resultado = ServicoCondutor.Editar(novoCondutor);

            //assert 
            resultado.Should().BeFailure();

            RepositorioCondutorMoq.Verify(x => x.Editar(novoCondutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_Condutor() //cenário 5
        {
            RepositorioCondutorMoq.Setup(x => x.Editar(It.IsAny<Condutor>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = ServicoCondutor.Editar(Condutor);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar condutor.");
        }


        [TestMethod]
        public void Deve_excluir_Condutor_caso_ele_esteja_cadastrado() //cenário 1
        {
            //arrange
            var condutor = new Condutor(Cliente
                                   , false
                                   , "Junior"
                                   , "exemplo@exemplo.exemplo"
                                   , "(00) 0 0000-0000"
                                   , "555.555.555-55"
                                   , "000000000000"
                                   , Convert.ToDateTime("05/02/2022"));

            RepositorioCondutorMoq.Setup(x => x.Existe(condutor))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = ServicoCondutor.Excluir(condutor);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioCondutorMoq.Verify(x => x.Excluir(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_Condutor_caso_ele_nao_esteja_cadastrado() //cenário 2
        {
            //arrange

            var condutor = new Condutor(Cliente
                                   , false
                                   , "Junior"
                                   , "exemplo@exemplo.exemplo"
                                   , "(00) 0 0000-0000"
                                   , "555.555.555-55"
                                   , "000000000000"
                                   , Convert.ToDateTime("05/02/2022"));

            RepositorioCondutorMoq.Setup(x => x.Existe(condutor))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = ServicoCondutor.Excluir(condutor);

            //assert 
            resultado.Should().BeFailure();
            RepositorioCondutorMoq.Verify(x => x.Excluir(condutor), Times.Never());
        }

        //TODO verificar quando o modulo que dependa deste modo estiver pronto implementar esse teste
        //[TestMethod]
        //public void Nao_deve_excluir_disciplina_caso_ele_esteja_relecionada_com_materia() //cenário 3
        //{            
        //    var disciplina = new Disciplina("Matemática");

        //    RepositorioCondutorMoq.Setup(x => x.Existe(disciplina))
        //       .Returns(() =>
        //       {
        //           return true;
        //       });

        //    // como configurar um método para ele lançar uma sqlexception utilizando moq

        //    RepositorioCondutorMoq.Setup(x => x.Excluir(It.IsAny<Disciplina>()))
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
        //    Result resultado = ServicoCondutor.Excluir(disciplina);

        //    //assert 
        //    resultado.Should().BeFailure();
        //    resultado.Reasons[0].Message.Should().Be("Esta disciplina está relacionada com uma matéria e não pode ser excluída");
        //}

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_Condutor() //cenário 4
        {
            var condutor = new Condutor(Cliente
                                   , false
                                   , "Junior"
                                   , "exemplo@exemplo.exemplo"
                                   , "(00) 0 0000-0000"
                                   , "555.555.555-55"
                                   , "000000000000"
                                   , Convert.ToDateTime("05/02/2022"));

            RepositorioCondutorMoq.Setup(x => x.Existe(condutor))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = ServicoCondutor.Excluir(condutor);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir condutor");
        }
    }
}
