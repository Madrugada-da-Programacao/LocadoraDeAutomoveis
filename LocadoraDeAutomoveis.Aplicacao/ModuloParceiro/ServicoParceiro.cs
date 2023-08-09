using LocadoraDeAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloParceiro
{
	public class ServicoParceiro
	{
		private readonly IRepositorioParceiro repositorioParceiro;
		private readonly IValidadorParceiro validador;
		private readonly IContextoPersistencia contextoPersistencia;

		public ServicoParceiro(IRepositorioParceiro repositorioParceiro, IValidadorParceiro validador, IContextoPersistencia contextoPersistencia)
		{
			this.repositorioParceiro = repositorioParceiro;
			this.validador = validador;
			this.contextoPersistencia = contextoPersistencia;
		}

		public Result Inserir(Parceiro registro)
		{
			Log.Debug("Tentando inserir parceiro...{@p}", registro);

			List<string> erros = ValidadorParceiro(registro);

			if (erros.Count() > 0)
			{
				contextoPersistencia.DesfazerAlteracoes();
				return Result.Fail(erros); //cenário 2
			}
			try
			{
				repositorioParceiro.Inserir(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Parceiro {ParceiroId} inserido com sucesso", registro.Id);

				return Result.Ok(); //cenário 1
			}
			catch (Exception exc)
			{
				contextoPersistencia.DesfazerAlteracoes();

				string msgErro = "Falha ao tentar inserir parceiro.";

				Log.Error(exc, msgErro + "{@p}", registro);

				return Result.Fail(msgErro); //cenário 3
			}
		}

		public Result Editar(Parceiro registro)
		{
			Log.Debug("Tentando editar parceiro...{@p}", registro);

			List<string> erros = ValidadorParceiro(registro);

			if (erros.Count() > 0)
			{
				contextoPersistencia.DesfazerAlteracoes();
				return Result.Fail(erros);
			}
			try
			{
				repositorioParceiro.Editar(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Parceiro {ParceiroId} editado com sucesso", registro.Id);

				return Result.Ok();
			}
			catch (Exception exc)
			{
				contextoPersistencia.DesfazerAlteracoes();

				string msgErro = "Falha ao tentar editar parceiro.";

				Log.Error(exc, msgErro + "{@p}", registro);

				return Result.Fail(msgErro);
			}
		}

		public Result Excluir(Parceiro registro)
		{
			Log.Debug("Tentando excluir parceiro...{@p}", registro);

			try
			{
				bool registroExiste = repositorioParceiro.Existe(registro);

				if (registroExiste == false)
				{
					Log.Warning("Parceiro {ParceiroId} não encontrado para excluir", registro.Id);

					return Result.Fail("Parceiro não encontrada");
				}

				repositorioParceiro.Excluir(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Parceiro {ParceiroId} excluído com sucesso", registro.Id);

				return Result.Ok();
			}
			catch (Exception ex)
			{
				contextoPersistencia.DesfazerAlteracoes();

				List<string> erros = new List<string>();

				string msgErro;

				//TODO adicionar a parte que cliente é dependente para gerar os errors quando tentar excluir
				//if (ex.Message.Contains("FK_TBMateria_TBDisciplina"))
				//	msgErro = "Esta disciplina está relacionada com uma matéria e não pode ser excluída";
				//else
				//	msgErro = "Falha ao tentar excluir disciplina";

				msgErro = "Falha ao tentar excluir parceiro";

				erros.Add(msgErro);

				Log.Error(ex, msgErro + " {ParceiroId}", registro.Id);

				return Result.Fail(erros);
			}
		}

		private List<string> ValidadorParceiro(Parceiro registro)
		{
			var resultadoValidacao = validador.Validate(registro);

			List<string> erros = new List<string>();

			if (resultadoValidacao != null)
				erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

			if (NomeParceiroDuplicado(registro))
				erros.Add($"Este nome '{registro.Nome}' já está sendo utilizado");

			foreach (string erro in erros)
			{
				Log.Warning(erro);
			}

			return erros;
		}

		private bool NomeParceiroDuplicado(Parceiro registro)
		{
			Parceiro? possivelRegistroComMesmoNome = repositorioParceiro.SelecionarPorNome(registro.Nome);

			if (possivelRegistroComMesmoNome != null &&
				possivelRegistroComMesmoNome.Id != registro.Id &&
				possivelRegistroComMesmoNome.Nome == registro.Nome)
			{
				return true;
			}

			return false;
		}
	}
}
