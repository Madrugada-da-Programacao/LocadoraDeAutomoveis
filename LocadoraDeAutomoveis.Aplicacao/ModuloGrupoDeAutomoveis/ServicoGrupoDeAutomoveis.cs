using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoDeAutomoveis
{
    public class ServicoGrupoDeAutomoveis
    {
        private readonly IRepositorioGrupoDeAutomoveis repositorioGrupoDeAutomoveis;
        private readonly IValidadorGrupoDeAutomoveis validadorGrupoDeAutomoveis;
		private readonly IContextoPersistencia contextoPersistencia;

		public ServicoGrupoDeAutomoveis(IRepositorioGrupoDeAutomoveis repositorioGrupoDeAutomoveis, IValidadorGrupoDeAutomoveis validadorGrupoDeAutomoveis, IContextoPersistencia contextoPersistencia)
		{
			this.repositorioGrupoDeAutomoveis = repositorioGrupoDeAutomoveis;
			this.validadorGrupoDeAutomoveis = validadorGrupoDeAutomoveis;
			this.contextoPersistencia = contextoPersistencia;
		}

		public Result Inserir(GrupoDeAutomoveis registro)
        {
            List<string> erros = ValidarGrupoDeAutomoveis(registro);

            if (erros.Count() > 0)
            {
				contextoPersistencia.DesfazerAlteracoes();
                return Result.Fail(erros);
			}
            try
            {
                repositorioGrupoDeAutomoveis.Inserir(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Grupo de Automoveis {GrupoID} inserido com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
				contextoPersistencia.DesfazerAlteracoes();

				string msgErro = "Falha ao tentar inserir grupo de automoveis.";

                Log.Error(exc, msgErro + "{@g}", registro);

                return Result.Fail(msgErro);
            }
        }

        private List<string> ValidarGrupoDeAutomoveis(GrupoDeAutomoveis registro)
        {
            var resultado = validadorGrupoDeAutomoveis.Validate(registro);

            List<string> erros = new List<string>();

            if (resultado != null)
                erros.AddRange(resultado.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(registro))
                erros.Add($"Este nome '{registro.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(GrupoDeAutomoveis registro)
        {
            GrupoDeAutomoveis? RegistroComMesmoNome = repositorioGrupoDeAutomoveis.SelecionarPorNome(registro.Nome);

            if (RegistroComMesmoNome != null &&
                RegistroComMesmoNome.Id != registro.Id &&
                RegistroComMesmoNome.Nome == registro.Nome)
            {
                return true;
            }

            return false;
        }

        public Result Editar(GrupoDeAutomoveis registro)
        {
            Log.Debug("Tentando editar grupo de automoveis...{@ga}", registro);

            List<string> erros = ValidarGrupoDeAutomoveis(registro);

            if (erros.Count() > 0)
            {
				contextoPersistencia.DesfazerAlteracoes();
                return Result.Fail(erros);
			}
            try
            {
                repositorioGrupoDeAutomoveis.Editar(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Grupo de Automoveis {GrupoID} editado com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
				contextoPersistencia.DesfazerAlteracoes();

				string msgErro = "Falha ao tentar editar Grupo de Automoveis.";

                Log.Error(exc, msgErro + "{@ga}", registro);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(GrupoDeAutomoveis registro)
        {
            Log.Debug("Tentando excluir grupo de automoveis...{@ga}", registro);

            try
            {
                bool grupoExiste = repositorioGrupoDeAutomoveis.Existe(registro);

                if (grupoExiste == false)
                {
                    Log.Warning("Grupo de Automoveis {GrupoID} não encontrado para excluir", registro.Id);

                    return Result.Fail("Grupo de Automoveis não encontrado");
                }

                repositorioGrupoDeAutomoveis.Excluir(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Grupo de Automoveis {GrupoID} excluído com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
				contextoPersistencia.DesfazerAlteracoes();

				List<string> erros = new List<string>();

                string msgErro;

                //TODO Adicionar Erros de exclusão de das caso algum modulo dependente esteja usando o grupo de automoveis
                //if (TemAutomovelNoGrupo(registro))
                //{
                //    string erro = "Existem Automoveis utilizando o grupo";
                //    erros.Add(erro);
                //}
                //if (UsadoporCobrança(registro)) 
                //{
                //    string erro = "Existe um plano de cobrança ao qual o grupo pertence";
                //    erros.Add(erro);
                //}
                //if (UsadoEmAluguel(registro))
                //{
                //    string erro = "Está sendo usado em um alguel ativo";
                //    erros.Add(erro);
                //}

                msgErro = "Falha ao tentar excluir Grupo de Automoveis";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {GrupoID}", registro.Id);

                return Result.Fail(erros);
            }
        }
    }
}
