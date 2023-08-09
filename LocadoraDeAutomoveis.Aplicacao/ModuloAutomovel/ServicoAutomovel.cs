using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAutomovel
{
    public class ServicoAutomovel
    {
        private IRepositorioAutomovel RepositorioAutomovel { get; set; }
        private IValidadorAutomovel ValidadorAutomovel { get; set; }

        public ServicoAutomovel(IRepositorioAutomovel repositorioAutomovel, IValidadorAutomovel validadorAutomovel)
        {
            RepositorioAutomovel = repositorioAutomovel;
            ValidadorAutomovel = validadorAutomovel;
        }

        private List<string> ValidarAutomovel(Automovel registro)
        {
            var resultado = ValidadorAutomovel.Validate(registro);

            List<string> erros = new List<string>();
            if(resultado != null)
                erros.AddRange(resultado.Errors.Select(x => x.ErrorMessage));
            if (PlacaDuplicada(registro))
                erros.Add($"Está placa {registro.Placa} já existe no sistema");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;

        }

        private bool PlacaDuplicada(Automovel registro)
        {
            Automovel? PossivelRegistroDuplicado = RepositorioAutomovel.SelecionarPorPlaca(registro.Placa);
            if(PossivelRegistroDuplicado != null 
                && PossivelRegistroDuplicado.Id != registro.Id 
                && PossivelRegistroDuplicado.Placa == registro.Placa)
            {
                return true;
            }
            return false;
        }

        public Result Inserir(Automovel registro)
        {
            Log.Debug("Tentando Inserir automovel...{@A}", registro);
            List<string> erros = ValidarAutomovel(registro);
            if(erros.Count > 0)
            {
                return Result.Fail(erros);
            }

            try
            {
                RepositorioAutomovel.Inserir(registro);

                Log.Debug("Automovel {AutomovelID} inserido com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir Automovel.";

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
                return Result.Fail(erros);
            }

            try
            {
                RepositorioAutomovel.Editar(registro);

                Log.Debug("Automovel {AutomovelID} Editado com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar Editar Automovel.";

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
                bool AutomovelExiste = RepositorioAutomovel.Existe(registro);
                if(!AutomovelExiste)
                {
                    Log.Warning("Automovel {AutomovelID} não encontrado para excluir", registro.Id);

                    return Result.Fail("Automovel não encontrado");
                }

                RepositorioAutomovel.Excluir(registro);

                Log.Debug("Automovel {AutomovelID} Excluido com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;
                
                //TODO Adicionar Erros de exclusão caso um aluguel ativo esteja utilizando o automovel
                //if (AluguelUtilizaAutomovel(registro))
                //{
                //    string erro = "Existe um Aluguel Ativo utilizando o automovel";
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
