using LocadoraDeAutomoveis.Dominio.ModuloAluguel;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel
{
    public class ServicoAluguel
    {
        private readonly IRepositorioAluguel repositorioAluguel;
        private readonly IValidadorAluguel validador;
        private readonly IContextoPersistencia contextoPersistencia;

        public ServicoAluguel(IRepositorioAluguel repositorioAluguel, IValidadorAluguel validador, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioAluguel = repositorioAluguel;
            this.validador = validador;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(Aluguel registro)
        {
            Log.Debug("Tentando inserir aluguel...{@a}", registro);

            List<string> erros = ValidadorAluguel(registro);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();
                return Result.Fail(erros); //cenário 2
            }
            try
            {
                repositorioAluguel.Inserir(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("Aluguel {AluguelId} inserida com sucesso", registro.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar inserir aluguel.";

                Log.Error(exc, msgErro + "{@a}", registro);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(Aluguel registro)
        {
            Log.Debug("Tentando editar aluguel...{@a}", registro);

            List<string> erros = ValidadorAluguel(registro);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();
                return Result.Fail(erros);
            }
            try
            {
                repositorioAluguel.Editar(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("Aluguel {AluguelId} editada com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar editar aluguel.";

                Log.Error(exc, msgErro + "{@a}", registro);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Aluguel registro)
        {
            Log.Debug("Tentando excluir aluguel...{@a}", registro);

            try
            {
                bool registroExiste = repositorioAluguel.Existe(registro);

                if (registroExiste == false)
                {
                    Log.Warning("Aluguel {AluguelId} não encontrado para excluir", registro.Id);

                    return Result.Fail("Aluguel não encontrado");
                }

                repositorioAluguel.Excluir(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("Aluguel {AluguelId} excluída com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro;

                msgErro = "Falha ao tentar excluir aluguel";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {AluguelId}", registro.Id);

                return Result.Fail(erros);
            }
        }



        private List<string> ValidadorAluguel(Aluguel registro)
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
