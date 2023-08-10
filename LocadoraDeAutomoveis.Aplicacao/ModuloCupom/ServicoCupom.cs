using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCupom;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCupom
{
	public class ServicoCupom
	{
		private readonly IRepositorioCupom repositorioCupom;
		private readonly IValidadorCupom validador;
		private readonly IContextoPersistencia contextoPersistencia;

		public ServicoCupom(IRepositorioCupom repositorioCupom, IValidadorCupom validador, IContextoPersistencia contextoPersistencia)
		{
			this.repositorioCupom = repositorioCupom;
			this.validador = validador;
			this.contextoPersistencia = contextoPersistencia;
		}

		public Result Inserir(Cupom registro)
		{
			Log.Debug("Tentando inserir cupom...{@c}", registro);

			List<string> erros = ValidadorCupom(registro);

			if (erros.Count() > 0)
			{
				contextoPersistencia.DesfazerAlteracoes();
				return Result.Fail(erros); //cenário 2
			}
			try
			{
				repositorioCupom.Inserir(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Cupom {CupomId} inserido com sucesso", registro.Id);

				return Result.Ok(); //cenário 1
			}
			catch (Exception exc)
			{
				contextoPersistencia.DesfazerAlteracoes();

				string msgErro = "Falha ao tentar inserir cupom.";

				Log.Error(exc, msgErro + "{@c}", registro);

				return Result.Fail(msgErro); //cenário 3
			}
		}

		public Result Editar(Cupom registro)
		{
			Log.Debug("Tentando editar cupom...{@c}", registro);

			List<string> erros = ValidadorCupom(registro);

			if (erros.Count() > 0)
			{
				contextoPersistencia.DesfazerAlteracoes();
				return Result.Fail(erros);
			}
			try
			{
				repositorioCupom.Editar(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Cupom {CupomId} editado com sucesso", registro.Id);

				return Result.Ok();
			}
			catch (Exception exc)
			{
				contextoPersistencia.DesfazerAlteracoes();

				string msgErro = "Falha ao tentar editar cupom.";

				Log.Error(exc, msgErro + "{@c}", registro);

				return Result.Fail(msgErro);
			}
		}

		public Result Excluir(Cupom registro)
		{
			Log.Debug("Tentando excluir cupom...{@c}", registro);

			try
			{
				bool registroExiste = repositorioCupom.Existe(registro);

				if (registroExiste == false)
				{
					Log.Warning("Cupom {CupomId} não encontrado para excluir", registro.Id);

					return Result.Fail("Cupom não encontrado");
				}

				repositorioCupom.Excluir(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Cupom {CupomId} excluído com sucesso", registro.Id);

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

				msgErro = "Falha ao tentar excluir cupom";

				erros.Add(msgErro);

				Log.Error(ex, msgErro + " {CupomId}", registro.Id);

				return Result.Fail(erros);
			}
		}

		private List<string> ValidadorCupom(Cupom registro)
		{
			var resultadoValidacao = validador.Validate(registro);

			List<string> erros = new List<string>();

			if (resultadoValidacao != null)
				erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

			if (NomeCupomDuplicado(registro))
				erros.Add($"Este nome '{registro.Nome}' já está sendo utilizado");

			foreach (string erro in erros)
			{
				Log.Warning(erro);
			}

			return erros;
		}

		private bool NomeCupomDuplicado(Cupom registro)
		{
			Cupom? possivelRegistroComMesmoNome = repositorioCupom.SelecionarPorNome(registro.Nome);

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
