using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutomovel;
using LocadoraDeAutomoveis.Aplicacao.ModuloCliente;
using LocadoraDeAutomoveis.Aplicacao.ModuloCupom;
using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCupom;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloParceiro;
using Moq;
using System.Numerics;

namespace LocadoraDeAutomoveis.TestesUnitarios.Aplicacao
{
	[TestClass]
	public class ServicoAutomovelTest
	{
		Mock<IRepositorioAutomovel> RepositorioAutomovelMoq { get; set; }
		Mock<IValidadorAutomovel> ValidadorAutomovelMoq { get; set; }
		Mock<IContextoPersistencia> ContextoPersistencia { get; set; }

		private ServicoAutomovel ServicoAutomovel { get; set; }

		GrupoDeAutomoveis GrupoDeAutomoveis { get; set; }
		Automovel Automovel { get; set; }

		public ServicoAutomovelTest()
		{
			RepositorioAutomovelMoq = new Mock<IRepositorioAutomovel>();
			ValidadorAutomovelMoq = new Mock<IValidadorAutomovel>();
			ContextoPersistencia = new Mock<IContextoPersistencia>();
			ServicoAutomovel = new ServicoAutomovel(RepositorioAutomovelMoq.Object, ValidadorAutomovelMoq.Object, ContextoPersistencia.Object);
			GrupoDeAutomoveis = new GrupoDeAutomoveis("4 por 4");
			
			Automovel = new Automovel("AAA-4444", "Fiat", "Preto", "Cronos", Automovel.TiposDeCombustivel.Gasolina, 20, DateTime.Now.AddYears(-2), 5, new byte[] { }, GrupoDeAutomoveis);
		}

		[TestMethod]
		public void Deve_inserir_automovel_caso_ele_for_valido() //cenário 1
		{
			//arrange
			Automovel = new Automovel("AAA-0000", "Fiat", "Preto", "Cronos", Automovel.TiposDeCombustivel.Gasolina, 20, DateTime.Now.AddYears(-2), 5, new byte[] { }, GrupoDeAutomoveis);

			//action
			Result resultado = ServicoAutomovel.Inserir(Automovel);

			//assert 
			resultado.Should().BeSuccess();
			RepositorioAutomovelMoq.Verify(x => x.Inserir(Automovel), Times.Once());
		}

		[TestMethod]
		public void Nao_deve_automovel_caso_ele_seja_invalido() //cenário 2
		{
			//arrange
			ValidadorAutomovelMoq.Setup(x => x.Validate(It.IsAny<Automovel>()))
				.Returns(() =>
				{
					var resultado = new ValidationResult();
					resultado.Errors.Add(new ValidationFailure("Imagem", "A imagem não pode ser maior do que 2 mb"));
					return resultado;
				});

			//action
			var resultado = ServicoAutomovel.Inserir(Automovel);

			//assert             
			resultado.Should().BeFailure();
			RepositorioAutomovelMoq.Verify(x => x.Inserir(Automovel), Times.Never());
		}

		[TestMethod]
		public void Nao_deve_inserir_automovel_caso_a_placa_ja_esteja_cadastrado() //cenário 3
		{
			//arrange
			string placa = "AAA-4444";

			RepositorioAutomovelMoq.Setup(x => x.SelecionarPorPlaca(placa))
				.Returns(() =>
				{
					return new Automovel(placa, "Fiat", "Preto", "Cronos", Automovel.TiposDeCombustivel.Gasolina, 20, DateTime.Now.AddYears(-2), 5, new byte[] { }, GrupoDeAutomoveis);
				});

			//action
			var resultado = ServicoAutomovel.Inserir(Automovel);

			//assert 
			resultado.Should().BeFailure();
			resultado.Reasons[0].Message.Should().Be($"Está placa '{placa}' já está sendo utilizado");
			RepositorioAutomovelMoq.Verify(x => x.Inserir(Automovel), Times.Never());
		}

		[TestMethod]
		public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_automovel() //cenário 4
		{
			RepositorioAutomovelMoq.Setup(x => x.Inserir(It.IsAny<Automovel>()))
				.Throws(() =>
				{
					return new Exception();
				});

			//action
			Result resultado = ServicoAutomovel.Inserir(Automovel);

			//assert 
			resultado.Should().BeFailure();
			resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir automovel.");
		}

		[TestMethod]
		public void Deve_editar_automovel_caso_ele_for_valido() //cenário 1
		{
			//arrange           
			Automovel = new Automovel("AAA-0000", "Fiat", "Preto", "Cronos", Automovel.TiposDeCombustivel.Gasolina, 20, DateTime.Now.AddYears(-2), 5, new byte[] { }, GrupoDeAutomoveis);

			//action
			Result resultado = ServicoAutomovel.Editar(Automovel);

			//assert 
			resultado.Should().BeSuccess();
			RepositorioAutomovelMoq.Verify(x => x.Editar(Automovel), Times.Once());
		}

		[TestMethod]
		public void Nao_deve_editar_automovel_caso_ele_seja_invalido() //cenário 2
		{
			//arrange
			ValidadorAutomovelMoq.Setup(x => x.Validate(It.IsAny<Automovel>()))
				.Returns(() =>
				{
					var resultado = new ValidationResult();
					resultado.Errors.Add(new ValidationFailure("Imagem", "A imagem não pode ser maior do que 2 mb"));
					return resultado;
				});

			//action
			var resultado = ServicoAutomovel.Editar(Automovel);

			//assert             
			resultado.Should().BeFailure();
			RepositorioAutomovelMoq.Verify(x => x.Editar(Automovel), Times.Never());
		}

		[TestMethod]
		public void Deve_editar_cliente_com_a_mesma_placa() //cenário 3
		{
			//arrange
			Guid id = Guid.NewGuid();
			string placa = "AAA-4444";

			RepositorioAutomovelMoq.Setup(x => x.SelecionarPorPlaca(placa))
				 .Returns(() =>
				 {
					 return new Automovel(id,
										placa,
										"Fiat",
										"Preto",
										"Cronos",
										Automovel.TiposDeCombustivel.Gasolina,
										20,
										DateTime.Now.AddYears(-2),
										5,
										new byte[] { },
										GrupoDeAutomoveis);
				 });

			Automovel outroAutomovel = new Automovel(id,
										placa,
										"Fiat",
										"Preto",
										"Cronos",
										Automovel.TiposDeCombustivel.Gasolina,
										20,
										DateTime.Now.AddYears(-2),
										5,
										new byte[] { },
										GrupoDeAutomoveis);

			//action
			var resultado = ServicoAutomovel.Editar(outroAutomovel);

			//assert 
			resultado.Should().BeSuccess();

			RepositorioAutomovelMoq.Verify(x => x.Editar(outroAutomovel), Times.Once());
		}

		[TestMethod]
		public void Nao_deve_editar_automovel_caso_a_placa_ja_esteja_cadastrada() //cenário 4
		{
			//arrange
			string placa = "AAA-4444";

			RepositorioAutomovelMoq.Setup(x => x.SelecionarPorPlaca(placa))
				 .Returns(() =>
				 {
					 return new Automovel(placa,
										"Fiat",
										"Preto",
										"Cronos",
										Automovel.TiposDeCombustivel.Gasolina,
										20,
										DateTime.Now.AddYears(-2),
										5,
										new byte[] { },
										GrupoDeAutomoveis);
				 });

			Automovel novoAutomovel = new Automovel(placa,
										"Fiat",
										"Preto",
										"Cronos",
										Automovel.TiposDeCombustivel.Gasolina,
										20,
										DateTime.Now.AddYears(-2),
										5,
										new byte[] { },
										GrupoDeAutomoveis);

			//action
			var resultado = ServicoAutomovel.Editar(novoAutomovel);

			//assert 
			resultado.Should().BeFailure();

			RepositorioAutomovelMoq.Verify(x => x.Editar(novoAutomovel), Times.Never());
		}

		[TestMethod]
		public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_automovel() //cenário 5
		{
			RepositorioAutomovelMoq.Setup(x => x.Editar(It.IsAny<Automovel>()))
				.Throws(() =>
				{
					return new Exception();
				});

			//action
			Result resultado = ServicoAutomovel.Editar(Automovel);

			//assert 
			resultado.Should().BeFailure();
			resultado.Errors[0].Message.Should().Be("Falha ao tentar editar automovel.");
		}

		[TestMethod]
		public void Deve_excluir_automovel_caso_ele_esteja_cadastrado() //cenário 1
		{
			//arrange
			var automovel = new Automovel("AAA-4444",
										"Fiat",
										"Preto",
										"Cronos",
										Automovel.TiposDeCombustivel.Gasolina,
										20,
										DateTime.Now.AddYears(-2),
										5,
										new byte[] { },
										GrupoDeAutomoveis);

			RepositorioAutomovelMoq.Setup(x => x.Existe(automovel))
			   .Returns(() =>
			   {
				   return true;
			   });

			//action
			var resultado = ServicoAutomovel.Excluir(automovel);

			//assert 
			resultado.Should().BeSuccess();
			RepositorioAutomovelMoq.Verify(x => x.Excluir(automovel), Times.Once());
		}

		[TestMethod]
		public void Nao_deve_excluirautomovel_caso_ele_nao_esteja_cadastrado() //cenário 2
		{
			//arrange

			var automovel = new Automovel("AAA-4444",
										"Fiat",
										"Preto",
										"Cronos",
										Automovel.TiposDeCombustivel.Gasolina,
										20,
										DateTime.Now.AddYears(-2),
										5,
										new byte[] { },
										GrupoDeAutomoveis);

			RepositorioAutomovelMoq.Setup(x => x.Existe(automovel))
			   .Returns(() =>
			   {
				   return false;
			   });

			//action
			var resultado = ServicoAutomovel.Excluir(automovel);

			//assert 
			resultado.Should().BeFailure();
			RepositorioAutomovelMoq.Verify(x => x.Excluir(automovel), Times.Never());
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
		public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_automovel() //cenário 4
		{
			var automovel = new Automovel("AAA-4444",
										"Fiat",
										"Preto",
										"Cronos",
										Automovel.TiposDeCombustivel.Gasolina,
										20,
										DateTime.Now.AddYears(-2),
										5,
										new byte[] { },
										GrupoDeAutomoveis);

			RepositorioAutomovelMoq.Setup(x => x.Existe(automovel))
			  .Throws(() =>
			  {
				  return SqlExceptionCreator.NewSqlException();
			  });

			//action
			Result resultado = ServicoAutomovel.Excluir(automovel);

			//assert 
			resultado.Should().BeFailure();
			resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir automovel");
		}

	}
}
