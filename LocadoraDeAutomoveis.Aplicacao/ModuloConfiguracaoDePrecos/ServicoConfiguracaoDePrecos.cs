using LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracaoDePrecos
{
    public class ServicoConfiguracaoDePrecos
    {
        private readonly IRepositorioConfiguracaoDePrecos repositorioConfiguracaoDePrecos;
        private readonly IValidadorConfiguracaoDePrecos validador;


        public ServicoConfiguracaoDePrecos(IRepositorioConfiguracaoDePrecos repositorioConfiguracaoDePrecos, IValidadorConfiguracaoDePrecos validadorConfiguracaoDePrecos)
        {
            this.repositorioConfiguracaoDePrecos = repositorioConfiguracaoDePrecos;
            validador = validadorConfiguracaoDePrecos;
        }

        public Result Editar(ConfiguracaoDePrecos registro)
        {
            Log.Debug("Tentando editar configuracaoDePrecos...{@c}", registro);

            List<string> erros = ValidadorConfiguracaoDePrecos(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioConfiguracaoDePrecos.Editar(registro);

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
