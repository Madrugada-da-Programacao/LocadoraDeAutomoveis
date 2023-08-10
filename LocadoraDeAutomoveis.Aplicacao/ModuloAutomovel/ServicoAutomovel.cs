using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAutomovel
{
	public class ServicoAutomovel
    {
        private readonly IRepositorioAutomovel repositorioAutomovel;
        private readonly IValidadorAutomovel validadorAutomovel;
		private readonly IContextoPersistencia contextoPersistencia;

		public ServicoAutomovel(IRepositorioAutomovel repositorioAutomovel, IValidadorAutomovel validadorAutomovel, IContextoPersistencia contextoPersistencia)
		{
			this.repositorioAutomovel = repositorioAutomovel;
			this.validadorAutomovel = validadorAutomovel;
			this.contextoPersistencia = contextoPersistencia;
		}

		public Result Inserir(Automovel registro)
        {
            Log.Debug("Tentando Inserir automovel...{@A}", registro);
            List<string> erros = ValidarAutomovel(registro);
            if(erros.Count > 0)
            {
				contextoPersistencia.DesfazerAlteracoes();
				return Result.Fail(erros);
            }

            try
            {
                repositorioAutomovel.Inserir(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Automovel {AutomovelID} inserido com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
				contextoPersistencia.DesfazerAlteracoes();

				string msgErro = "Falha ao tentar inserir automovel.";

                Log.Error(exc, msgErro + "{@A}", registro);

                return Result.Fail(msgErro);
            }
        }
        public Result Editar(Automovel registro)
        {
            Log.Debug("Tentando editar automovel...{@A}", registro);
            List<string> erros = ValidarAutomovel(registro);
            if(erros.Count > 0)
            {
				contextoPersistencia.DesfazerAlteracoes();

				return Result.Fail(erros);
            }

            try
            {
                repositorioAutomovel.Editar(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Automovel {AutomovelID} editado com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
				contextoPersistencia.DesfazerAlteracoes();

				string msgErro = "Falha ao tentar editar automovel.";

                //TODO Adicionar Erros de Edição caso um aluguel ativo esteja utilizando o automovel
                //if (AluguelUtilizaAutomovel(registro))
                //{
                //    string erro = "Existe um Aluguel Ativo utilizando o automovel";
                //    erros.Add(erro);
                //}

                Log.Error(exc, msgErro + "{@A}", registro);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(Automovel registro)
        {
            Log.Debug("Tentando excluir automovel...{@A}", registro);
            try
            {
                bool AutomovelExiste = repositorioAutomovel.Existe(registro);
                if(!AutomovelExiste)
                {
                    Log.Warning("Automovel {AutomovelID} não encontrado para excluir", registro.Id);

                    return Result.Fail("Automovel não encontrado");
                }

                repositorioAutomovel.Excluir(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Automovel {AutomovelID} excluido com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
				contextoPersistencia.DesfazerAlteracoes();

				List<string> erros = new List<string>();

                string msgErro;
                
                //TODO Adicionar Erros de exclusão caso um aluguel ativo esteja utilizando o automovel
                //if (AluguelUtilizaAutomovel(registro))
                //{
                //    string erro = "Existe um Aluguel Ativo utilizando o automovel";
                //    erros.Add(erro);
                //}

                msgErro = "Falha ao tentar excluir automovel";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {GrupoID}", registro.Id);

                return Result.Fail(erros);
            }
        }

		private List<string> ValidarAutomovel(Automovel registro)
		{
			var resultado = validadorAutomovel.Validate(registro);

			List<string> erros = new List<string>();
			if (resultado != null)
				erros.AddRange(resultado.Errors.Select(x => x.ErrorMessage));
			if (PlacaDuplicada(registro))
				erros.Add($"Está placa '{registro.Placa}' já está sendo utilizado");

			foreach (string erro in erros)
			{
				Log.Warning(erro);
			}

			return erros;
		}

		private bool PlacaDuplicada(Automovel registro)
		{
			Automovel? PossivelRegistroDuplicado = repositorioAutomovel.SelecionarPorPlaca(registro.Placa);
			if (PossivelRegistroDuplicado != null
				&& PossivelRegistroDuplicado.Id != registro.Id
				&& PossivelRegistroDuplicado.Placa == registro.Placa)
			{
				return true;
			}
			return false;
		}
	}
}
