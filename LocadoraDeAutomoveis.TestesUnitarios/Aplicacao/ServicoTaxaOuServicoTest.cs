using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaOuServico;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;
using Moq;

namespace LocadoraDeAutomoveis.TestesUnitarios.Aplicacao
{
    [TestClass]
    public class ServicoTaxaOuServicoTest
    {
        Mock<IRepositorioTaxaOuServico> RepositorioTaxaOuServicoMoq { get; set; }
        Mock<IValidadorTaxaOuServico> ValidadorTaxaOuServicoMoq { get; set; }

        private ServicoTaxaOuServico ServicoTaxaOuServico { get; set; }

        TaxaOuServico TaxaOuServico { get; set; }

        public ServicoTaxaOuServicoTest()
        {
            RepositorioTaxaOuServicoMoq = new Mock<IRepositorioTaxaOuServico>();
			ValidadorTaxaOuServicoMoq = new Mock<IValidadorTaxaOuServico>();
            ServicoTaxaOuServico = new ServicoTaxaOuServico(RepositorioTaxaOuServicoMoq.Object, ValidadorTaxaOuServicoMoq.Object);
			TaxaOuServico = new TaxaOuServico("Lavar o carro"
                                             ,0.01m
                                             ,TaxaOuServico.TipoDeCobranca.PrecoFixo);
        }

        [TestMethod]
        public void Deve_inserir_taxa_ou_servico_caso_ela_for_valida() //cenário 1
        {
			//arrange
			TaxaOuServico = new TaxaOuServico("Lavar o carro"
											 , 0.01m
											 , TaxaOuServico.TipoDeCobranca.PrecoFixo);

			//action
			Result resultado = ServicoTaxaOuServico.Inserir(TaxaOuServico);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioTaxaOuServicoMoq.Verify(x => x.Inserir(TaxaOuServico), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_taxa_ou_servico_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            ValidadorTaxaOuServicoMoq.Setup(x => x.Validate(It.IsAny<TaxaOuServico>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = ServicoTaxaOuServico.Inserir(TaxaOuServico);

            //assert             
            resultado.Should().BeFailure();
            RepositorioTaxaOuServicoMoq.Verify(x => x.Inserir(TaxaOuServico), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_taxa_ou_servico_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeTaxaOuservico = "Lavar o carro";

            RepositorioTaxaOuServicoMoq.Setup(x => x.SelecionarPorNome(nomeTaxaOuservico))
                .Returns(() =>
                {
					return  new TaxaOuServico("Lavar o carro"
											 , 0.01m
											 , TaxaOuServico.TipoDeCobranca.PrecoFixo);
				});

            //action
            var resultado = ServicoTaxaOuServico.Inserir(TaxaOuServico);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeTaxaOuservico}' já está sendo utilizado");
            RepositorioTaxaOuServicoMoq.Verify(x => x.Inserir(TaxaOuServico), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_taxa_ou_servico() //cenário 4
        {
            RepositorioTaxaOuServicoMoq.Setup(x => x.Inserir(It.IsAny<TaxaOuServico>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = ServicoTaxaOuServico.Inserir(TaxaOuServico);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir taxa ou serviço.");
        }


        [TestMethod]
        public void Deve_editar_taxa_ou_servico_caso_ele_for_valido() //cenário 1
        {
			//arrange           
			TaxaOuServico = new TaxaOuServico("Lavar o carro"
											 , 0.01m
											 , TaxaOuServico.TipoDeCobranca.PrecoFixo);

			//action
			Result resultado = ServicoTaxaOuServico.Editar(TaxaOuServico);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioTaxaOuServicoMoq.Verify(x => x.Editar(TaxaOuServico), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_taxa_ou_servico_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            ValidadorTaxaOuServicoMoq.Setup(x => x.Validate(It.IsAny<TaxaOuServico>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = ServicoTaxaOuServico.Editar(TaxaOuServico);

            //assert             
            resultado.Should().BeFailure();
            RepositorioTaxaOuServicoMoq.Verify(x => x.Editar(TaxaOuServico), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_taxa_ou_servico_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Guid id = Guid.NewGuid();
            string nomeTaxaOuServico = "Lavar o carro";

            RepositorioTaxaOuServicoMoq.Setup(x => x.SelecionarPorNome(nomeTaxaOuServico))
                 .Returns(() =>
                 {
                     return new TaxaOuServico(id
                                             , nomeTaxaOuServico
											 , 0.01m
											 , TaxaOuServico.TipoDeCobranca.PrecoFixo);
				 });

            TaxaOuServico outraTaxaOuServico = new TaxaOuServico(id
											                , nomeTaxaOuServico
											                , 0.01m
											                , TaxaOuServico.TipoDeCobranca.PrecoFixo);

			//action
			var resultado = ServicoTaxaOuServico.Editar(outraTaxaOuServico);

            //assert 
            resultado.Should().BeSuccess();

            RepositorioTaxaOuServicoMoq.Verify(x => x.Editar(outraTaxaOuServico), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_taxa_ou_servico_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            string nomeTaxaOuServico = "Lavar o carro";

            RepositorioTaxaOuServicoMoq.Setup(x => x.SelecionarPorNome(nomeTaxaOuServico))
                 .Returns(() =>
                 {
                     return new TaxaOuServico(nomeTaxaOuServico
											 , 0.01m
											 , TaxaOuServico.TipoDeCobranca.PrecoFixo);
				 });

            TaxaOuServico novaTaxaOuServico = new TaxaOuServico(nomeTaxaOuServico
											 , 0.01m
											 , TaxaOuServico.TipoDeCobranca.PrecoFixo);

			//action
			var resultado = ServicoTaxaOuServico.Editar(novaTaxaOuServico);

            //assert 
            resultado.Should().BeFailure();

            RepositorioTaxaOuServicoMoq.Verify(x => x.Editar(novaTaxaOuServico), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_taxa_ou_servico() //cenário 5
        {
            RepositorioTaxaOuServicoMoq.Setup(x => x.Editar(It.IsAny<TaxaOuServico>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = ServicoTaxaOuServico.Editar(TaxaOuServico);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar taxa ou serviço.");
        }


        [TestMethod]
        public void Deve_excluir_taxa_ou_servico_caso_ela_esteja_cadastrada() //cenário 1
        {
            //arrange
            var taxaOuServico = new TaxaOuServico("Lavar o carro"
											 , 0.01m
											 , TaxaOuServico.TipoDeCobranca.PrecoFixo);

			RepositorioTaxaOuServicoMoq.Setup(x => x.Existe(taxaOuServico))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = ServicoTaxaOuServico.Excluir(taxaOuServico);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioTaxaOuServicoMoq.Verify(x => x.Excluir(taxaOuServico), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_taxa_ou_servico_caso_ela_nao_esteja_cadastrada() //cenário 2
        {
            //arrange

            var taxaOuServico = new TaxaOuServico("Lavar o carro"
											 , 0.01m
											 , TaxaOuServico.TipoDeCobranca.PrecoFixo);

			RepositorioTaxaOuServicoMoq.Setup(x => x.Existe(taxaOuServico))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = ServicoTaxaOuServico.Excluir(taxaOuServico);

            //assert 
            resultado.Should().BeFailure();
            RepositorioTaxaOuServicoMoq.Verify(x => x.Excluir(taxaOuServico), Times.Never());
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
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_taxa_ou_servico() //cenário 4
        {
            var taxaOuServico = new TaxaOuServico("Lavar o carro"
											 , 0.01m
											 , TaxaOuServico.TipoDeCobranca.PrecoFixo);

			RepositorioTaxaOuServicoMoq.Setup(x => x.Existe(taxaOuServico))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = ServicoTaxaOuServico.Excluir(taxaOuServico);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir taxa ou serviço");
        }

    }
}