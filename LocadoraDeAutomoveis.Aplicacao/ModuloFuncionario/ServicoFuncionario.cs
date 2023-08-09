using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private readonly IRepositorioFuncionario repositorioFuncionario;
        private readonly IValidadorFuncionario validadorFuncionario;
		private readonly IContextoPersistencia contextoPersistencia;

		public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario, IValidadorFuncionario validadorFuncionario, IContextoPersistencia contextoPersistencia)
		{
			this.repositorioFuncionario = repositorioFuncionario;
			this.validadorFuncionario = validadorFuncionario;
			this.contextoPersistencia = contextoPersistencia;
		}

		public Result Inserir(Funcionario registro)
        {
            Log.Debug("Tentando inserir funcionario...{@f}", registro);

            List<string> erros = ValidarFuncionario(registro);

            if (erros.Count() > 0)
            {
				contextoPersistencia.DesfazerAlteracoes();
                return Result.Fail(erros); //cenário 2
			}
            try
            {
                repositorioFuncionario.Inserir(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Funcionario {FuncionarioId} inserido com sucesso", registro.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
				contextoPersistencia.DesfazerAlteracoes();

				string msgErro = "Falha ao tentar inserir funcionario.";

                Log.Error(exc, msgErro + "{@f}", registro);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(Funcionario registro)
        {
            Log.Debug("Tentando editar funcionario...{@f}", registro);

            List<string> erros = ValidarFuncionario(registro);

            if (erros.Count() > 0)
            {
				contextoPersistencia.DesfazerAlteracoes();
                return Result.Fail(erros);
			}
            try
            {
                repositorioFuncionario.Editar(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Funcionario {FuncionarioId} editado com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
				contextoPersistencia.DesfazerAlteracoes();

				string msgErro = "Falha ao tentar editar funcionario.";

                Log.Error(exc, msgErro + "{@f}", registro);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Funcionario registro)
        {
            Log.Debug("Tentando excluir funcionario...{@f}", registro);

            try
            {
                bool funcionarioExiste = repositorioFuncionario.Existe(registro);

                if (funcionarioExiste == false)
                {
                    Log.Warning("Funcionario {FuncionarioId} não encontrado para excluir", registro.Id);

                    return Result.Fail("Funcionario não encontrado");
                }

                repositorioFuncionario.Excluir(registro);

				contextoPersistencia.GravarDados();

				Log.Debug("Funcionario {FuncionarioId} excluído com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
				contextoPersistencia.DesfazerAlteracoes();

				List<string> erros = new List<string>();

                string msgErro;

                //TODO adicionar a parte que funcionario é dependente para gerar os errors quando tentar excluir
                //if (ex.Message.Contains("FK_TBMateria_TBFuncionario"))
                //	msgErro = "Esta funcionario está relacionada com uma matéria e não pode ser excluído";
                //else
                //	msgErro = "Falha ao tentar excluir funcionario";

                msgErro = "Falha ao tentar excluir funcionario";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {FuncionarioId}", registro.Id);

                return Result.Fail(erros);
            }
        }



        private List<string> ValidarFuncionario(Funcionario registro)
        {
            var resultadoValidacao = validadorFuncionario.Validate(registro);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(registro))
                erros.Add($"Este nome '{registro.Nome}' já está sendo utilizado");

            if (DataNoFuturo(registro))
                erros.Add("A Data de Admissão precisa estar no passado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool DataNoFuturo(Funcionario registro)
        {
            if (registro.DataAdmissao > DateTime.Now)
                return true;

            return false;
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            Funcionario? funcionarioEncontrado = repositorioFuncionario.SelecionarPorNome(funcionario.Nome);

            if (funcionarioEncontrado != null &&
                funcionarioEncontrado.Id != funcionario.Id &&
                funcionarioEncontrado.Nome == funcionario.Nome)
            {
                return true;
            }

            return false;
        }
    }
}
