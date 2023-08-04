using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoDeAutomoveis
{
    public class ServicoGrupoDeAutomoveis
    {
        private IRepositorioGrupoDeAutomoveis RepositorioGrupoDeAutomoveis { get; set; }
        private IValidadorGrupoDeAutomoveis ValidadorGrupoDeAutomoveis { get; set; }

        public ServicoGrupoDeAutomoveis(IRepositorioGrupoDeAutomoveis repositorioGrupoDeAutomoveis, IValidadorGrupoDeAutomoveis validadorGrupoDeAutomoveis)
        {
            RepositorioGrupoDeAutomoveis = repositorioGrupoDeAutomoveis;
            ValidadorGrupoDeAutomoveis = validadorGrupoDeAutomoveis;
        }

        public Result Inserir(GrupoDeAutomoveis registro)
        {
            List<string> erros = ValidarGrupoDeAutomoveis(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                RepositorioGrupoDeAutomoveis.Inserir(registro);

                Log.Debug("Grupo de Automoveis {GrupoID} inserido com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir grupo de automoveis.";

                Log.Error(exc, msgErro + "{@c}", registro);

                return Result.Fail(msgErro);
            }
        }

        private List<string> ValidarGrupoDeAutomoveis(GrupoDeAutomoveis registro)
        {
            var resultado = ValidadorGrupoDeAutomoveis.Validate(registro);

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
            GrupoDeAutomoveis? RegistroComMesmoNome = RepositorioGrupoDeAutomoveis.SelecionarPorNome(registro.Nome);

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
                return Result.Fail(erros);

            try
            {
                RepositorioGrupoDeAutomoveis.Editar(registro);

                Log.Debug("Grupo de Automoveis {GrupoID} editado com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
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
                bool disciplinaExiste = RepositorioGrupoDeAutomoveis.Existe(registro);

                if (disciplinaExiste == false)
                {
                    Log.Warning("Grupo de Automoveis {GrupoID} não encontrado para excluir", registro.Id);

                    return Result.Fail("Grupo de Automoveis não encontrado");
                }

                RepositorioGrupoDeAutomoveis.Excluir(registro);

                Log.Debug("Grupo de Automoveis {GrupoID} excluído com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
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
