using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca
    {
        private readonly IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;
        private readonly IValidadorPlanoDeCobranca validador;
		private readonly IContextoPersistencia contextoPersistencia;

		public ServicoPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca, IValidadorPlanoDeCobranca validador, IContextoPersistencia contextoPersistencia)
		{
			this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
			this.validador = validador;
			this.contextoPersistencia = contextoPersistencia;
		}

		public Result Inserir(PlanoDeCobranca registro)
        {
            Log.Debug("Tentando inserir plano de cobranca...{@p}", registro);

            List<string> erros = ValidadorPlanoDeCobranca(registro);

            if (erros.Count() > 0)
            {
				contextoPersistencia.DesfazerAlteracoes();
                return Result.Fail(erros); //cenário 2
			}
            try
            {
                repositorioPlanoDeCobranca.Inserir(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("PlanoDeCobranca {PlanoDeCobrancaId} inserida com sucesso", registro.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
				contextoPersistencia.DesfazerAlteracoes();

				string msgErro = "Falha ao tentar inserir plano de cobranca.";

                Log.Error(exc, msgErro + "{@p}", registro);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(PlanoDeCobranca registro)
        {
            Log.Debug("Tentando editar plano de cobranca...{@p}", registro);

            List<string> erros = ValidadorPlanoDeCobranca(registro);

            if (erros.Count() > 0)
            {
				contextoPersistencia.DesfazerAlteracoes();
                return Result.Fail(erros);
			}
            try
            {
                repositorioPlanoDeCobranca.Editar(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("PlanoDeCobranca {PlanoDeCobrancaId} editada com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
				contextoPersistencia.DesfazerAlteracoes();

				string msgErro = "Falha ao tentar editar plano de cobranca.";

                Log.Error(exc, msgErro + "{@p}", registro);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(PlanoDeCobranca registro)
        {
            Log.Debug("Tentando excluir plano de cobranca...{@p}", registro);

            try
            {
                bool registroExiste = repositorioPlanoDeCobranca.Existe(registro);

                if (registroExiste == false)
                {
                    Log.Warning("PlanoDeCobranca {PlanoDeCobrancaId} não encontrada para excluir", registro.Id);

                    return Result.Fail("PlanoDeCobranca não encontrada");
                }

                repositorioPlanoDeCobranca.Excluir(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("PlanoDeCobranca {PlanoDeCobrancaId} excluída com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
				contextoPersistencia.DesfazerAlteracoes();

				List<string> erros = new List<string>();

                string msgErro;

                //TODO Aluguel adicionar a parte que planoDeCobranca é dependente para gerar os errors quando tentar excluir
                //if (ex.Message.Contains("FK_TBMateria_TBDisciplina"))
                //	msgErro = "Esta disciplina está relacionada com uma matéria e não pode ser excluída";
                //else
                //	msgErro = "Falha ao tentar excluir disciplina";

                msgErro = "Falha ao tentar excluir plano de cobranca";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {PlanoDeCobrancaId}", registro.Id);

                return Result.Fail(erros);
            }
        }



        private List<string> ValidadorPlanoDeCobranca(PlanoDeCobranca registro)
        {
            var resultadoValidacao = validador.Validate(registro);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }
    }
}
