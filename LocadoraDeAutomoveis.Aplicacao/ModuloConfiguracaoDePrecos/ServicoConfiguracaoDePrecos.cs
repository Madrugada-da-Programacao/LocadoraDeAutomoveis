using LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracaoDePrecos
{
    public class ServicoConfiguracaoDePrecos
    {
        private IRepositorioConfiguracaoDePrecos RepositorioConfiguracaoDePrecos { get; set; }
        private IValidadorConfiguracaoDePrecos Validador { get; set; }

        public ServicoConfiguracaoDePrecos(IRepositorioConfiguracaoDePrecos repositorioConfiguracaoDePrecos, IValidadorConfiguracaoDePrecos validadorConfiguracaoDePrecos)
        {
            RepositorioConfiguracaoDePrecos = repositorioConfiguracaoDePrecos;
            Validador = validadorConfiguracaoDePrecos;
        }

        public Result Editar(ConfiguracaoDePrecos registro)
        {
            Log.Debug("Tentando editar configuracaoDePrecos...{@c}", registro);

            List<string> erros = ValidadorConfiguracaoDePrecos(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                RepositorioConfiguracaoDePrecos.Editar(registro);

                Log.Debug("Configuracao de Preços editada com sucesso!");

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar Configuracao de Preços.";

                Log.Error(exc, msgErro + "{@c}", registro);

                return Result.Fail(msgErro);
            }
        }


        private List<string> ValidadorConfiguracaoDePrecos(ConfiguracaoDePrecos registro)
        {
            var resultadoValidacao = Validador.Validate(registro);

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
