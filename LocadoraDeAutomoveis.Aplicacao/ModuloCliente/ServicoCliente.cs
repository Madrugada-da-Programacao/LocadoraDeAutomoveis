using LocadoraDeAutomoveis.Dominio.ModuloCliente;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCliente
{
	public class ServicoCliente
	{
		private readonly IRepositorioCliente repositorioCliente;
		private readonly IValidadorCliente validador;
		private readonly IContextoPersistencia contextoPersistencia;

		public ServicoCliente(IRepositorioCliente repositorioCliente, IValidadorCliente validador, IContextoPersistencia contextoPersistencia)
		{
			this.repositorioCliente = repositorioCliente;
			this.validador = validador;
			this.contextoPersistencia = contextoPersistencia;
		}

		public Result Inserir(Cliente registro)
		{
			Log.Debug("Tentando inserir cliente...{@c}", registro);

			List<string> erros = ValidadorCliente(registro);

			if (erros.Count() > 0)
			{
				contextoPersistencia.DesfazerAlteracoes();
				return Result.Fail(erros); //cenário 2
			}
			try
			{
				repositorioCliente.Inserir(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Cliente {ClienteId} inserida com sucesso", registro.Id);

				return Result.Ok(); //cenário 1
			}
			catch (Exception exc)
			{
				contextoPersistencia.DesfazerAlteracoes();

				string msgErro = "Falha ao tentar inserir cliente.";

				Log.Error(exc, msgErro + "{@c}", registro);

				return Result.Fail(msgErro); //cenário 3
			}
		}

		public Result Editar(Cliente registro)
		{
			Log.Debug("Tentando editar cliente...{@c}", registro);

			List<string> erros = ValidadorCliente(registro);

			if (erros.Count() > 0)
			{
				contextoPersistencia.DesfazerAlteracoes();
				return Result.Fail(erros);
			}
			try
			{
				repositorioCliente.Editar(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Cliente {ClienteId} editada com sucesso", registro.Id);

				return Result.Ok();
			}
			catch (Exception exc)
			{
				contextoPersistencia.DesfazerAlteracoes();

				string msgErro = "Falha ao tentar editar cliente.";

				Log.Error(exc, msgErro + "{@c}", registro);

				return Result.Fail(msgErro);
			}
		}

		public Result Excluir(Cliente registro)
		{
			Log.Debug("Tentando excluir cliente...{@c}", registro);

			try
			{
				bool registroExiste = repositorioCliente.Existe(registro);

				if (registroExiste == false)
				{
					Log.Warning("Cliente {ClienteId} não encontrada para excluir", registro.Id);

					return Result.Fail("Cliente não encontrada");
				}

				repositorioCliente.Excluir(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Cliente {ClienteId} excluída com sucesso", registro.Id);

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

				msgErro = "Falha ao tentar excluir cliente";

				erros.Add(msgErro);

				Log.Error(ex, msgErro + " {ClienteId}", registro.Id);

				return Result.Fail(erros);
			}
		}



		private List<string> ValidadorCliente(Cliente registro)
		{
			var resultadoValidacao = validador.Validate(registro);

			List<string> erros = new List<string>();

			if (resultadoValidacao != null)
				erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

			if (NomeETipoDeClienteDuplicado(registro))
				erros.Add($"Este nome '{registro.Nome}' com este tipo de cliente {registro.TipoCliente}já está sendo utilizado");

			foreach (string erro in erros)
			{
				Log.Warning(erro);
			}

			return erros;
		}

		private bool NomeETipoDeClienteDuplicado(Cliente registro)
		{
			Cliente? possivelRegistroComMesmoNomeETipoDeCliente = repositorioCliente.SelecionarPorNomeETipoDeCliente(registro.Nome, registro.TipoCliente);

			if (possivelRegistroComMesmoNomeETipoDeCliente != null &&
				possivelRegistroComMesmoNomeETipoDeCliente.Id != registro.Id &&
				possivelRegistroComMesmoNomeETipoDeCliente.Nome == registro.Nome &&
				possivelRegistroComMesmoNomeETipoDeCliente.TipoCliente == registro.TipoCliente)
			{
				return true;
			}

			return false;
		}
	}
}
