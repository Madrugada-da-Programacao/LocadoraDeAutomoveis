using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeAutomoveis.Aplicacao.ModuloCliente;
using LocadoraDeAutomoveis.Dominio;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using Microsoft.Win32;
using Moq;

namespace LocadoraDeAutomoveis.TestesUnitarios.Aplicacao
{
    [TestClass]
    public class ServicoClienteTest
    {
        Mock<IRepositorioCliente> RepositorioClienteMoq { get; set; }
        Mock<IValidadorCliente> ValidadorDisciplinaMoq { get; set; }

        private ServicoCliente ServicoCliente { get; set; }

        Cliente Cliente { get; set; }

        public ServicoClienteTest()
        {
            RepositorioClienteMoq = new Mock<IRepositorioCliente>();
            ValidadorDisciplinaMoq = new Mock<IValidadorCliente>();
            ServicoCliente = new ServicoCliente(RepositorioClienteMoq.Object, ValidadorDisciplinaMoq.Object);
            Cliente = new Cliente("Bob"
								 ,Cliente.TipoDeCliente.PessoaFisica
								 ,"000.000.000-00"
								 ,"exemplo@exemplo.exemplo"
								 ,"(00) 0 0000-0000"
								 ,"SC"
								 ,"Lages"
								 ,"Centro"
								 ,"Frei Gabriel"
								 ,1);
        }

        [TestMethod]
        public void Deve_inserir_cliente_caso_ele_for_valido() //cenário 1
        {
			//arrange
			Cliente = new Cliente("Bob"
								 ,Cliente.TipoDeCliente.PessoaFisica
								 ,"000.000.000-00"
								 ,"exemplo@exemplo.exemplo"
								 ,"(00) 0 0000-0000"
								 ,"SC"
								 ,"Lages"
								 ,"Centro"
								 ,"Frei Gabriel"
								 ,1);

			//action
			Result resultado = ServicoCliente.Inserir(Cliente);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioClienteMoq.Verify(x => x.Inserir(Cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_cliente_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            ValidadorDisciplinaMoq.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = ServicoCliente.Inserir(Cliente);

            //assert             
            resultado.Should().BeFailure();
            RepositorioClienteMoq.Verify(x => x.Inserir(Cliente), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_cliente_caso_o_nome_e_tipo_de_cliente_pessoa_fisica_ja_esteja_cadastrado() //cenário 3.1
        {
            //arrange
            string nomeCliente = "Bob";
            Cliente.TipoDeCliente tipoDeCliente = Cliente.TipoDeCliente.PessoaFisica;

            RepositorioClienteMoq.Setup(x => x.SelecionarPorNomeETipoDeCliente(nomeCliente, tipoDeCliente))
                .Returns(() =>
                {
					return new Cliente(nomeCliente
								      ,tipoDeCliente
									  , "000.000.000-00"
								      ,"exemplo@exemplo.exemplo"
								      ,"(00) 0 0000-0000"
								      ,"SC"
								      ,"Lages"
								      ,"Centro"
								      ,"Frei Gabriel"
								      ,1);
				});
          
            //action
            var resultado = ServicoCliente.Inserir(Cliente);

            //assert 
            resultado.Should().BeFailure();
			resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeCliente}' com este tipo de cliente {tipoDeCliente}já está sendo utilizado");
			RepositorioClienteMoq.Verify(x => x.Inserir(Cliente), Times.Never());
		}

		[TestMethod]
		public void Nao_deve_inserir_cliente_caso_o_nome_e_tipo_de_cliente_pessoa_juridica_ja_esteja_cadastrado() //cenário 3.2
		{
			//arrange
			string nomeCliente = "Bob";
			Cliente.TipoDeCliente tipoDeCliente = Cliente.TipoDeCliente.PessoaJuridica;
            Cliente.TipoCliente = tipoDeCliente;
            Cliente.NumeroDoDocumento = "00.000.000/0000-00";

			RepositorioClienteMoq.Setup(x => x.SelecionarPorNomeETipoDeCliente(nomeCliente, tipoDeCliente))
				.Returns(() =>
				{
					return new Cliente(nomeCliente
									  ,tipoDeCliente
									  ,"00.000.000/0000-00"
									  ,"exemplo@exemplo.exemplo"
									  ,"(00) 0 0000-0000"
									  ,"SC"
									  ,"Lages"
									  ,"Centro"
									  ,"Frei Gabriel"
									  ,1);
				});

			//action
			var resultado = ServicoCliente.Inserir(Cliente);

			//assert 
			resultado.Should().BeFailure();
			resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeCliente}' com este tipo de cliente {tipoDeCliente}já está sendo utilizado");
			RepositorioClienteMoq.Verify(x => x.Inserir(Cliente), Times.Never());
		}

		[TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_cliente() //cenário 4
        {
            RepositorioClienteMoq.Setup(x => x.Inserir(It.IsAny<Cliente>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = ServicoCliente.Inserir(Cliente);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir cliente.");
        }


        [TestMethod]
        public void Deve_editar_cliente_caso_ele_for_valido() //cenário 1
        {
			//arrange           
			Cliente = new Cliente("Ricardo"
								 ,Cliente.TipoDeCliente.PessoaFisica
								 ,"000.000.000-00"
								 ,"exemplo@exemplo.exemplo"
								 ,"(00) 0 0000-0000"
								 ,"SC"
								 ,"Lages"
								 ,"Centro"
								 ,"Frei Gabriel"
								 ,1);

			//action
			Result resultado = ServicoCliente.Editar(Cliente);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioClienteMoq.Verify(x => x.Editar(Cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_cliente_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            ValidadorDisciplinaMoq.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = ServicoCliente.Editar(Cliente);

            //assert             
            resultado.Should().BeFailure();
            RepositorioClienteMoq.Verify(x => x.Editar(Cliente), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_disciplina_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Guid id = Guid.NewGuid();
			string nomeCliente = "Bob";
			Cliente.TipoDeCliente tipoDeCliente = Cliente.TipoDeCliente.PessoaFisica;

			RepositorioClienteMoq.Setup(x => x.SelecionarPorNomeETipoDeCliente(nomeCliente, tipoDeCliente))
                 .Returns(() =>
                 {
					 return new Cliente(id
                                      ,nomeCliente
									  ,tipoDeCliente
									  ,"00.000.000/0000-00"
									  ,"exemplo@exemplo.exemplo"
									  ,"(00) 0 0000-0000"
									  ,"SC"
									  ,"Lages"
									  ,"Centro"
									  ,"Frei Gabriel"
									  ,1);
				 });

            Cliente outraDisciplina = new Cliente(id
									            , nomeCliente
									            , tipoDeCliente
									            , "00.000.000/0000-00"
									            , "exemplo@exemplo.exemplo"
									            , "(00) 0 0000-0000"
									            , "SC"
									            , "Lages"
									            , "Centro"
									            , "Frei Gabriel"
									            , 1);

			//action
			var resultado = ServicoCliente.Editar(outraDisciplina);

            //assert 
            resultado.Should().BeSuccess();

            RepositorioClienteMoq.Verify(x => x.Editar(outraDisciplina), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_cliente_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
			//arrange
			string nomeCliente = "Bob";
			Cliente.TipoDeCliente tipoDeCliente = Cliente.TipoDeCliente.PessoaFisica;

			RepositorioClienteMoq.Setup(x => x.SelecionarPorNomeETipoDeCliente(nomeCliente, tipoDeCliente))
				 .Returns(() =>
                 {
                     return new Cliente(nomeCliente
									  , tipoDeCliente
									  , "00.000.000/0000-00"
									  , "exemplo@exemplo.exemplo"
									  , "(00) 0 0000-0000"
									  , "SC"
									  , "Lages"
									  , "Centro"
									  , "Frei Gabriel"
									  , 1);
				 });

            Cliente novaDisciplina = new Cliente(nomeCliente
									          , tipoDeCliente
									          , "00.000.000/0000-00"
									          , "exemplo@exemplo.exemplo"
									          , "(00) 0 0000-0000"
									          , "SC"
									          , "Lages"
									          , "Centro"
									          , "Frei Gabriel"
									          , 1); ;

            //action
            var resultado = ServicoCliente.Editar(novaDisciplina);

            //assert 
            resultado.Should().BeFailure();

            RepositorioClienteMoq.Verify(x => x.Editar(novaDisciplina), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_cliente() //cenário 5
        {
            RepositorioClienteMoq.Setup(x => x.Editar(It.IsAny<Cliente>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = ServicoCliente.Editar(Cliente);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar cliente.");
        }


        [TestMethod]
        public void Deve_excluir_disciplina_caso_ela_esteja_cadastrada() //cenário 1
        {
            //arrange
            var disciplina = new Cliente("Bob"
								 , Cliente.TipoDeCliente.PessoaFisica
								 , "000.000.000-00"
								 , "exemplo@exemplo.exemplo"
								 , "(00) 0 0000-0000"
								 , "SC"
								 , "Lages"
								 , "Centro"
								 , "Frei Gabriel"
								 , 1);

			RepositorioClienteMoq.Setup(x => x.Existe(disciplina))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = ServicoCliente.Excluir(disciplina);

            //assert 
            resultado.Should().BeSuccess();
            RepositorioClienteMoq.Verify(x => x.Excluir(disciplina), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_cliente_caso_ela_nao_esteja_cadastrada() //cenário 2
        {
            //arrange

            var disciplina = new Cliente("Bob"
								       , Cliente.TipoDeCliente.PessoaFisica
								       , "000.000.000-00"
								       , "exemplo@exemplo.exemplo"
								       , "(00) 0 0000-0000"
								       , "SC"
								       , "Lages"
								       , "Centro"
								       , "Frei Gabriel"
								       , 1);

			RepositorioClienteMoq.Setup(x => x.Existe(disciplina))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = ServicoCliente.Excluir(disciplina);

            //assert 
            resultado.Should().BeFailure();
            RepositorioClienteMoq.Verify(x => x.Excluir(disciplina), Times.Never());
        }

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
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_cliente() //cenário 4
        {
            var disciplina = new Cliente("Bob"
								       , Cliente.TipoDeCliente.PessoaFisica
								       , "000.000.000-00"
								       , "exemplo@exemplo.exemplo"
								       , "(00) 0 0000-0000"
								       , "SC"
								       , "Lages"
								       , "Centro"
								       , "Frei Gabriel"
								       , 1);

			RepositorioClienteMoq.Setup(x => x.Existe(disciplina))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = ServicoCliente.Excluir(disciplina);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir cliente");
        }

    }    
}