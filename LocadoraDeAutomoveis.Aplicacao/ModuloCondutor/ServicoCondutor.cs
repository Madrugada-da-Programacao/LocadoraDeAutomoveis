using LocadoraDeAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private readonly IRepositorioCondutor repositorioCondutor;
        private readonly IValidadorCondutor validador;
        private readonly IContextoPersistencia contextoPersistencia;
        public ServicoCondutor(IRepositorioCondutor repositorioCondutor, IValidadorCondutor validador, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.validador = validador;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(Condutor registro)
        {
            Log.Debug("Tentando inserir condutor...{@c}", registro);

            List<string> erros = ValidadorCondutor(registro);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();
                return Result.Fail(erros); //cenário 2
            }
            try
            {
                repositorioCondutor.Inserir(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("Condutor {CondutorId} inserida com sucesso", registro.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar inserir condutor.";

                Log.Error(exc, msgErro + "{@c}", registro);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(Condutor registro)
        {
            Log.Debug("Tentando editar condutor...{@c}", registro);

            List<string> erros = ValidadorCondutor(registro);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();
                return Result.Fail(erros);
            }
            try
            {
                repositorioCondutor.Editar(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("Condutor {CondutorId} editada com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar editar condutor.";

                Log.Error(exc, msgErro + "{@c}", registro);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Condutor registro)
        {
            Log.Debug("Tentando excluir condutor...{@c}", registro);

            try
            {
                bool registroExiste = repositorioCondutor.Existe(registro);

                if (registroExiste == false)
                {
                    Log.Warning("Condutor {CondutorId} não encontrada para excluir", registro.Id);

                    return Result.Fail("Condutor não encontrada");
                }

                repositorioCondutor.Excluir(registro);

                contextoPersistencia.GravarDados();

                Log.Debug("Condutor {CondutorId} excluída com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro;

                //TODO adicionar a parte que condutor é dependente para gerar os errors quando tentar excluir
                //if (ex.Message.Contains("FK_TBMateria_TBDisciplina"))
                //	msgErro = "Esta disciplina está relacionada com uma matéria e não pode ser excluída";
                //else
                //	msgErro = "Falha ao tentar excluir disciplina";

                msgErro = "Falha ao tentar excluir condutor";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {CondutorId}", registro.Id);

                return Result.Fail(erros);
            }
        }



        private List<string> ValidadorCondutor(Condutor registro)
        {
            var resultadoValidacao = validador.Validate(registro);

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

        private bool NomeDuplicado(Condutor registro)
        {
            Condutor? possivelRegistroComMesmoNome = repositorioCondutor.SelecionarPorNome(registro.Nome);

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
