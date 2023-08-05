using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloTaxaOuServico
{
	public class ServicoTaxaOuServico
	{
		private IRepositorioTaxaOuServico RepositorioTaxaOuServico{ get; set; }
		private IValidadorTaxaOuServico Validador{ get; set; }

		public ServicoTaxaOuServico(IRepositorioTaxaOuServico repositorioTaxaOuServico, IValidadorTaxaOuServico validadorTaxaOuServico)
		{
			RepositorioTaxaOuServico = repositorioTaxaOuServico;
			Validador = validadorTaxaOuServico;
		}

		public Result Inserir(Dominio.ModuloTaxaOuServico.TaxaOuServico registro)
		{
			Log.Debug("Tentando inserir taxa ou serviço...{@t}", registro);

			List<string> erros = ValidadorTaxaOuServico(registro);

			if (erros.Count() > 0)
				return Result.Fail(erros); //cenário 2

			try
			{
				RepositorioTaxaOuServico.Inserir(registro);

				Log.Debug("Taxa ou Serviço {TaxaOuServicoId} inserida com sucesso", registro.Id);

				return Result.Ok(); //cenário 1
			}
			catch (Exception exc)
			{
				string msgErro = "Falha ao tentar inserir taxa ou serviço.";

				Log.Error(exc, msgErro + "{@t}", registro);

				return Result.Fail(msgErro); //cenário 3
			}
		}

		public Result Editar(Dominio.ModuloTaxaOuServico.TaxaOuServico registro)
		{
			Log.Debug("Tentando editar taxa ou serviço...{@t}", registro);

			List<string> erros = ValidadorTaxaOuServico(registro);

			if (erros.Count() > 0)
				return Result.Fail(erros);

			try
			{
				RepositorioTaxaOuServico.Editar(registro);

				Log.Debug("Taxa ou Serviço {TaxaOuServicoId} editada com sucesso", registro.Id);

				return Result.Ok();
			}
			catch (Exception exc)
			{
				string msgErro = "Falha ao tentar editar taxa ou serviço.";

				Log.Error(exc, msgErro + "{@t}", registro);

				return Result.Fail(msgErro);
			}
		}

		public Result Excluir(Dominio.ModuloTaxaOuServico.TaxaOuServico registro)
		{
			Log.Debug("Tentando excluir taxa ou serviço...{@t}", registro);

			try
			{
				bool registroExiste = RepositorioTaxaOuServico.Existe(registro);

				if (registroExiste == false)
				{
					Log.Warning("Taxa ou Serviço {TaxaOuServicoId} não encontrada para excluir", registro.Id);

					return Result.Fail("Taxa ou Serviço não encontrada");
				}

				RepositorioTaxaOuServico.Excluir(registro);

				Log.Debug("Taxa ou Serviço {TaxaOuServicoId} excluída com sucesso", registro.Id);

				return Result.Ok();
			}
			catch (SqlException ex)
			{
				List<string> erros = new List<string>();

				string msgErro;

				//TODO adicionar a parte que cliente é dependente para gerar os errors quando tentar excluir
				//if (ex.Message.Contains("FK_TBMateria_TBDisciplina"))
				//	msgErro = "Esta disciplina está relacionada com uma matéria e não pode ser excluída";
				//else
				//	msgErro = "Falha ao tentar excluir disciplina";

				msgErro = "Falha ao tentar excluir taxa ou serviço";

				erros.Add(msgErro);

				Log.Error(ex, msgErro + " {TaxaOuServicoId}", registro.Id);

				return Result.Fail(erros);
			}
		}



		private List<string> ValidadorTaxaOuServico(Dominio.ModuloTaxaOuServico.TaxaOuServico registro)
		{
			var resultadoValidacao = Validador.Validate(registro);

			List<string> erros = new List<string>();

			if (resultadoValidacao != null)
				erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

			if (NomeDuplicado(registro))
				erros.Add($"Este nome '{registro.Nome}' já está sendo utilizado");

			foreach (string erro in erros)
			{
				Log.Warning(erro);
			}

			return erros;
		}

		private bool NomeDuplicado(Dominio.ModuloTaxaOuServico.TaxaOuServico registro)
		{
			Dominio.ModuloTaxaOuServico.TaxaOuServico? possivelRegistroComMesmo = RepositorioTaxaOuServico.SelecionarPorNome(registro.Nome);

			if (possivelRegistroComMesmo != null &&
				possivelRegistroComMesmo.Id != registro.Id &&
				possivelRegistroComMesmo.Nome == registro.Nome)
			{
				return true;
			}

			return false;
		}
	}
}
