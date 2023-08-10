using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeAutomoveis.Aplicacao.ModuloCupom;
using LocadoraDeAutomoveis.Dominio.ModuloCupom;
using LocadoraDeAutomoveis.Dominio.ModuloParceiro;
using Moq;

namespace LocadoraDeAutomoveis.TestesUnitarios.Aplicacao
{
	[TestClass]
	public class ServicoCupomTest
	{
		Mock<IRepositorioCupom> RepositorioCupomMoq { get; set; }
		Mock<IValidadorCupom> ValidadorCupomMoq { get; set; }
		Mock<IContextoPersistencia> ContextoPersistencia { get; set; }

		private ServicoCupom ServicoCupom { get; set; }

		Parceiro Parceiro { get; set; }
		Cupom Cupom { get; set; }

		public ServicoCupomTest()
		{
			RepositorioCupomMoq = new Mock<IRepositorioCupom>();
			ValidadorCupomMoq = new Mock<IValidadorCupom>();
			ContextoPersistencia = new Mock<IContextoPersistencia>();
			ServicoCupom = new ServicoCupom(RepositorioCupomMoq.Object, ValidadorCupomMoq.Object, ContextoPersistencia.Object);
			Parceiro = new Parceiro("Americanas");
			Cupom = new Cupom("Desconto de Natal", 15, DateTime.Now.AddMonths(1), Parceiro);
		}

		[TestMethod]
		public void Deve_inserir_cupom_caso_ele_for_valido() //cenário 1
		{
			//arrange
			Cupom = new Cupom("Desconto de Natal", 15, DateTime.Now.AddMonths(1), Parceiro);

			//action
			Result resultado = ServicoCupom.Inserir(Cupom);

			//assert 
			resultado.Should().BeSuccess();
			RepositorioCupomMoq.Verify(x => x.Inserir(Cupom), Times.Once());
		}

		[TestMethod]
		public void Nao_deve_inserircupom_caso_ele_seja_invalido() //cenário 2
		{
			//arrange
			ValidadorCupomMoq.Setup(x => x.Validate(It.IsAny<Cupom>()))
				.Returns(() =>
				{
					var resultado = new ValidationResult();
					resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
					return resultado;
				});

			//action
			var resultado = ServicoCupom.Inserir(Cupom);

			//assert             
			resultado.Should().BeFailure();
			RepositorioCupomMoq.Verify(x => x.Inserir(Cupom), Times.Never());
		}

		[TestMethod]
		public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_cupom() //cenário 4
		{
			RepositorioCupomMoq.Setup(x => x.Inserir(It.IsAny<Cupom>()))
				.Throws(() =>
				{
					return new Exception();
				});

			//action
			Result resultado = ServicoCupom.Inserir(Cupom);

			//assert 
			resultado.Should().BeFailure();
			resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir cupom.");
		}

		[TestMethod]
		public void Deve_editar_cupom_caso_ele_for_valido() //cenário 1
		{
			//arrange           
			Cupom = new Cupom("Desconto de Natal", 15, DateTime.Now.AddMonths(1), Parceiro);

			//action
			Result resultado = ServicoCupom.Editar(Cupom);

			//assert 
			resultado.Should().BeSuccess();
			RepositorioCupomMoq.Verify(x => x.Editar(Cupom), Times.Once());
		}

		[TestMethod]
		public void Nao_deve_editar_cupom_caso_ele_seja_invalido() //cenário 2
		{
			//arrange
			ValidadorCupomMoq.Setup(x => x.Validate(It.IsAny<Cupom>()))
				.Returns(() =>
				{
					var resultado = new ValidationResult();
					resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
					return resultado;
				});

			//action
			var resultado = ServicoCupom.Editar(Cupom);

			//assert             
			resultado.Should().BeFailure();
			RepositorioCupomMoq.Verify(x => x.Editar(Cupom), Times.Never());
		}

		[TestMethod]
		public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_plano_de_cobranca() //cenário 5
		{
			RepositorioCupomMoq.Setup(x => x.Editar(It.IsAny<Cupom>()))
				.Throws(() =>
				{
					return new Exception();
				});

			//action
			Result resultado = ServicoCupom.Editar(Cupom);

			//assert 
			resultado.Should().BeFailure();
			resultado.Errors[0].Message.Should().Be("Falha ao tentar editar cupom.");
		}

		[TestMethod]
		public void Deve_excluir_cupom_caso_ela_esteja_cadastrada() //cenário 1
		{
			//arrange
			Cupom = new Cupom("Desconto de Natal", 15, DateTime.Now.AddMonths(1), Parceiro);

			RepositorioCupomMoq.Setup(x => x.Existe(Cupom))
			   .Returns(() =>
			   {
				   return true;
			   });

			//action
			var resultado = ServicoCupom.Excluir(Cupom);

			//assert 
			resultado.Should().BeSuccess();
			RepositorioCupomMoq.Verify(x => x.Excluir(Cupom), Times.Once());
		}

		[TestMethod]
		public void Nao_deve_excluir_cupom_caso_ele_nao_esteja_cadastrado() //cenário 2
		{
			//arrange

			Cupom = new Cupom("Desconto de Natal", 15, DateTime.Now.AddMonths(1), Parceiro);

			RepositorioCupomMoq.Setup(x => x.Existe(Cupom))
			   .Returns(() =>
			   {
				   return false;
			   });

			//action
			var resultado = ServicoCupom.Excluir(Cupom);

			//assert 
			resultado.Should().BeFailure();
			RepositorioCupomMoq.Verify(x => x.Excluir(Cupom), Times.Never());
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
		public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_cupom() //cenário 4
		{
			Cupom = new Cupom("Desconto de Natal", 15, DateTime.Now.AddMonths(1), Parceiro);

			RepositorioCupomMoq.Setup(x => x.Existe(Cupom))
			  .Throws(() =>
			  {
				  return SqlExceptionCreator.NewSqlException();
			  });

			//action
			Result resultado = ServicoCupom.Excluir(Cupom);

			//assert 
			resultado.Should().BeFailure();
			resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir cupom");
		}
	}
}
