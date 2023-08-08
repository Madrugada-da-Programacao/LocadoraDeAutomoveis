using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;
using Moq;

namespace LocadoraDeAutomoveis.TestesUnitarios.Aplicacao
{
    public class ServicoPlanoDeCobrancaTest
    {
        Mock<IRepositorioPlanoDeCobranca> RepositorioPlanoDeCobrancaMoq { get; set; }
        Mock<IValidadorPlanoDeCobranca> ValidadorPlanoDeCobrancaMoq { get; set; }

        private ServicoPlanoDeCobranca ServicoPlanoDeCobranca { get; set; }

        PlanoDeCobranca PlanoDeCobranca { get; set; }
        GrupoDeAutomoveis Grupo { get; set; }

        public ServicoPlanoDeCobrancaTest()
        {
            RepositorioPlanoDeCobrancaMoq = new Mock<IRepositorioPlanoDeCobranca>();
            ValidadorPlanoDeCobrancaMoq = new Mock<IValidadorPlanoDeCobranca>();
            ServicoPlanoDeCobranca = new ServicoPlanoDeCobranca(RepositorioPlanoDeCobrancaMoq.Object, ValidadorPlanoDeCobrancaMoq.Object);
            Grupo = new GrupoDeAutomoveis("Carros");
            PlanoDeCobranca = new PlanoDeCobranca(Grupo, 5, 5, 5, 5, 5, 5);
        }

        [TestMethod]
        public void Deve_inserir_plano_de_cobranca_caso_ela_for_valida() //cenário 1
        {
            //arrange
            PlanoDeCobranca = new PlanoDeCobranca(Grupo, 5, 5, 5, 5, 5, 5);

            //action
            Result resultado = ServicoPlanoDeCobranca.Inserir(PlanoDeCobranca);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioPlanoDeCobrancaMoq.Verify(x => x.Inserir(PlanoDeCobranca), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_plano_de_cobranca_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            ValidadorPlanoDeCobrancaMoq.Setup(x => x.Validate(It.IsAny<PlanoDeCobranca>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = ServicoPlanoDeCobranca.Inserir(PlanoDeCobranca);

            //assert             
            resultado.Should().BeFailure();
            RepositorioPlanoDeCobrancaMoq.Verify(x => x.Inserir(PlanoDeCobranca), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_plano_de_cobranca_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomePlanoDeCobranca = "Lavar o carro";

            RepositorioPlanoDeCobrancaMoq.Setup(x => x.SelecionarPorNome(nomePlanoDeCobranca))
                .Returns(() =>
                {
                    return new PlanoDeCobranca(Grupo, 5, 5, 5, 5, 5, 5);
                });

            //action
            var resultado = ServicoPlanoDeCobranca.Inserir(PlanoDeCobranca);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomePlanoDeCobranca}' já está sendo utilizado");
            RepositorioPlanoDeCobrancaMoq.Verify(x => x.Inserir(PlanoDeCobranca), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_plano_de_cobranca() //cenário 4
        {
            RepositorioPlanoDeCobrancaMoq.Setup(x => x.Inserir(It.IsAny<PlanoDeCobranca>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = ServicoPlanoDeCobranca.Inserir(PlanoDeCobranca);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir plano de cobranca.");
        }


        [TestMethod]
        public void Deve_editar_plano_de_cobranca_caso_ele_for_valido() //cenário 1
        {
            //arrange           
            PlanoDeCobranca = new PlanoDeCobranca(Grupo, 5, 5, 5, 5, 5, 5);

            //action
            Result resultado = ServicoPlanoDeCobranca.Editar(PlanoDeCobranca);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioPlanoDeCobrancaMoq.Verify(x => x.Editar(PlanoDeCobranca), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_plano_de_cobranca_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            ValidadorPlanoDeCobrancaMoq.Setup(x => x.Validate(It.IsAny<PlanoDeCobranca>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = ServicoPlanoDeCobranca.Editar(PlanoDeCobranca);

            //assert             
            resultado.Should().BeFailure();
            RepositorioPlanoDeCobrancaMoq.Verify(x => x.Editar(PlanoDeCobranca), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_plano_de_cobranca_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Guid id = Guid.NewGuid();
            string nomePlanoDeCobranca = "Lavar o carro";

            RepositorioPlanoDeCobrancaMoq.Setup(x => x.SelecionarPorNome(nomePlanoDeCobranca))
                 .Returns(() =>
                 {
                     return new PlanoDeCobranca(id
                                             , nomePlanoDeCobranca
                                             , 0.01m
                                             , PlanoDeCobranca.TipoDeCobranca.PrecoFixo);
                 });

            PlanoDeCobranca outraPlanoDeCobranca = new PlanoDeCobranca(id
                                                            , nomePlanoDeCobranca
                                                            , 0.01m
                                                            , PlanoDeCobranca.TipoDeCobranca.PrecoFixo);

            //action
            var resultado = ServicoPlanoDeCobranca.Editar(outraPlanoDeCobranca);

            //assert 
            resultado.Should().BeSuccess();

            RepositorioPlanoDeCobrancaMoq.Verify(x => x.Editar(outraPlanoDeCobranca), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_plano_de_cobranca_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            string nomePlanoDeCobranca = "Lavar o carro";

            RepositorioPlanoDeCobrancaMoq.Setup(x => x.SelecionarPorNome(nomePlanoDeCobranca))
                 .Returns(() =>
                 {
                     return new PlanoDeCobranca(nomePlanoDeCobranca
                                             , 0.01m
                                             , PlanoDeCobranca.TipoDeCobranca.PrecoFixo);
                 });

            PlanoDeCobranca novaPlanoDeCobranca = new PlanoDeCobranca(nomePlanoDeCobranca
                                             , 0.01m
                                             , PlanoDeCobranca.TipoDeCobranca.PrecoFixo);

            //action
            var resultado = ServicoPlanoDeCobranca.Editar(novaPlanoDeCobranca);

            //assert 
            resultado.Should().BeFailure();

            RepositorioPlanoDeCobrancaMoq.Verify(x => x.Editar(novaPlanoDeCobranca), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_plano_de_cobranca() //cenário 5
        {
            RepositorioPlanoDeCobrancaMoq.Setup(x => x.Editar(It.IsAny<PlanoDeCobranca>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = ServicoPlanoDeCobranca.Editar(PlanoDeCobranca);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar plano de cobranca.");
        }


        [TestMethod]
        public void Deve_excluir_plano_de_cobranca_caso_ela_esteja_cadastrada() //cenário 1
        {
            //arrange
            var PlanoDeCobranca = new PlanoDeCobranca(Grupo, 5, 5, 5, 5, 5, 5);

            RepositorioPlanoDeCobrancaMoq.Setup(x => x.Existe(PlanoDeCobranca))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = ServicoPlanoDeCobranca.Excluir(PlanoDeCobranca);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioPlanoDeCobrancaMoq.Verify(x => x.Excluir(PlanoDeCobranca), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_plano_de_cobranca_caso_ela_nao_esteja_cadastrada() //cenário 2
        {
            //arrange

            var PlanoDeCobranca = new PlanoDeCobranca(Grupo, 5, 5, 5, 5, 5, 5);

            RepositorioPlanoDeCobrancaMoq.Setup(x => x.Existe(PlanoDeCobranca))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = ServicoPlanoDeCobranca.Excluir(PlanoDeCobranca);

            //assert 
            resultado.Should().BeFailure();
            RepositorioPlanoDeCobrancaMoq.Verify(x => x.Excluir(PlanoDeCobranca), Times.Never());
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
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_plano_de_cobranca() //cenário 4
        {
            var PlanoDeCobranca = new PlanoDeCobranca(Grupo, 5, 5, 5, 5, 5, 5);

            RepositorioPlanoDeCobrancaMoq.Setup(x => x.Existe(PlanoDeCobranca))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = ServicoPlanoDeCobranca.Excluir(PlanoDeCobranca);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir plano de cobranca");
        }
    }
}
