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
            Log.Debug("Tentando inserir cliente...{@c}", registro);

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

                string msgErro = "Falha ao tentar inserir cliente.";

                Log.Error(exc, msgErro + "{@c}", registro);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(Aluguel registro)
        {
            Log.Debug("Tentando editar cliente...{@c}", registro);

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

                string msgErro = "Falha ao tentar editar cliente.";

                Log.Error(exc, msgErro + "{@c}", registro);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Aluguel registro)
        {
            Log.Debug("Tentando excluir cliente...{@c}", registro);

            try
            {
                bool registroExiste = repositorioAluguel.Existe(registro);

                if (registroExiste == false)
                {
                    Log.Warning("Aluguel {AluguelId} não encontrada para excluir", registro.Id);

                    return Result.Fail("Aluguel não encontrada");
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

                //TODO adicionar a parte que cliente é dependente para gerar os errors quando tentar excluir
                //if (ex.Message.Contains("FK_TBMateria_TBDisciplina"))
                //	msgErro = "Esta disciplina está relacionada com uma matéria e não pode ser excluída";
                //else
                //	msgErro = "Falha ao tentar excluir disciplina";

                msgErro = "Falha ao tentar excluir cliente";

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

            if (NomeETipoDeAluguelDuplicado(registro))
                erros.Add($"Este nome '{registro.Nome}' com este tipo de cliente {registro.TipoAluguel}já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }
        private bool NomeETipoDeAluguelDuplicado(Aluguel registro)
        {
            Aluguel? possivelRegistroComMesmoNomeETipoDeAluguel = repositorioAluguel.SelecionarPorNomeETipoDeAluguel(registro.Nome, registro.TipoAluguel);

            if (possivelRegistroComMesmoNomeETipoDeAluguel != null &&
                possivelRegistroComMesmoNomeETipoDeAluguel.Id != registro.Id &&
                possivelRegistroComMesmoNomeETipoDeAluguel.Nome == registro.Nome &&
                possivelRegistroComMesmoNomeETipoDeAluguel.TipoAluguel == registro.TipoAluguel)
            {
                return true;
            }

            return false;
        }
    }
}
