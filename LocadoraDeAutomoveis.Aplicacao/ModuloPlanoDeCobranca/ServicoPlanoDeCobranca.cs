using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca
    {
        private IRepositorioPlanoDeCobranca RepositorioPlanoDeCobranca { get; set; }
        private IValidadorPlanoDeCobranca Validador { get; set; }

        public ServicoPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca, IValidadorPlanoDeCobranca validadorPlanoDeCobranca)
        {
            RepositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
            Validador = validadorPlanoDeCobranca;
        }

        public Result Inserir(PlanoDeCobranca registro)
        {
            Log.Debug("Tentando inserir planoDeCobranca...{@p}", registro);

            List<string> erros = ValidadorPlanoDeCobranca(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros); //cenário 2

            try
            {
                RepositorioPlanoDeCobranca.Inserir(registro);

                Log.Debug("PlanoDeCobranca {PlanoDeCobrancaId} inserida com sucesso", registro.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir planoDeCobranca.";

                Log.Error(exc, msgErro + "{@p}", registro);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(PlanoDeCobranca registro)
        {
            Log.Debug("Tentando editar planoDeCobranca...{@p}", registro);

            List<string> erros = ValidadorPlanoDeCobranca(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                RepositorioPlanoDeCobranca.Editar(registro);

                Log.Debug("PlanoDeCobranca {PlanoDeCobrancaId} editada com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar planoDeCobranca.";

                Log.Error(exc, msgErro + "{@p}", registro);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(PlanoDeCobranca registro)
        {
            Log.Debug("Tentando excluir planoDeCobranca...{@p}", registro);

            try
            {
                bool registroExiste = RepositorioPlanoDeCobranca.Existe(registro);

                if (registroExiste == false)
                {
                    Log.Warning("PlanoDeCobranca {PlanoDeCobrancaId} não encontrada para excluir", registro.Id);

                    return Result.Fail("PlanoDeCobranca não encontrada");
                }

                RepositorioPlanoDeCobranca.Excluir(registro);

                Log.Debug("PlanoDeCobranca {PlanoDeCobrancaId} excluída com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

                //TODO adicionar a parte que planoDeCobranca é dependente para gerar os errors quando tentar excluir
                //if (ex.Message.Contains("FK_TBMateria_TBDisciplina"))
                //	msgErro = "Esta disciplina está relacionada com uma matéria e não pode ser excluída";
                //else
                //	msgErro = "Falha ao tentar excluir disciplina";

                msgErro = "Falha ao tentar excluir planoDeCobranca";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {PlanoDeCobrancaId}", registro.Id);

                return Result.Fail(erros);
            }
        }



        private List<string> ValidadorPlanoDeCobranca(PlanoDeCobranca registro)
        {
            var resultadoValidacao = Validador.Validate(registro);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            //if (NomeETipoDePlanoDeCobrancaDuplicado(registro))
            //    erros.Add($"Este nome '{registro.Nome}' com este tipo de planoDeCobranca {registro.TipoPlanoDeCobranca}já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        //private bool NomeETipoDePlanoDeCobrancaDuplicado(PlanoDeCobranca registro)
        //{
        //    PlanoDeCobranca? possivelRegistroComMesmoNomeETipoDePlanoDeCobranca = RepositorioPlanoDeCobranca.SelecionarPorNomeETipoDePlanoDeCobranca(registro.Nome, registro.TipoPlanoDeCobranca);

        //    if (possivelRegistroComMesmoNomeETipoDePlanoDeCobranca != null &&
        //        possivelRegistroComMesmoNomeETipoDePlanoDeCobranca.Id != registro.Id &&
        //        possivelRegistroComMesmoNomeETipoDePlanoDeCobranca.Nome == registro.Nome &&
        //        possivelRegistroComMesmoNomeETipoDePlanoDeCobranca.TipoPlanoDeCobranca == registro.TipoPlanoDeCobranca)
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}
