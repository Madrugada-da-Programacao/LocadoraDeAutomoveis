using LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace LocadoraDeAutomoveis.Infra.Dados.Arquivo.Compartilhado
{
    public class ContextoDados
    {
        private string nomeArquivo = "Compartilhado\\LocadoraDeAutomoveis.json";

        public ConfiguracaoDePrecos ConfiguracaoDePrecos { get; set; }

        public ContextoDados()
        {
            ConfiguracaoDePrecos = new ConfiguracaoDePrecos();
        }
        public ContextoDados(string nomeArquivo)
        {
            this.nomeArquivo = nomeArquivo;
            ConfiguracaoDePrecos = new ConfiguracaoDePrecos();
        }

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados)
                CarregarDoArquivoJson();
        }

        public void GravarEmArquivoJson()
        {
            JsonSerializerOptions config = ObterConfiguracoes();

            string registrosJson = JsonSerializer.Serialize(this, config);

            File.WriteAllText(nomeArquivo, registrosJson);
        }

        private void CarregarDoArquivoJson()
        {
            JsonSerializerOptions config = ObterConfiguracoes();

            if (File.Exists(nomeArquivo))
            {
                string registrosJson = File.ReadAllText(nomeArquivo);

                if (registrosJson.Length > 0)
                {
                    ContextoDados? ctx = JsonSerializer.Deserialize<ContextoDados>(registrosJson, config);

                    this.ConfiguracaoDePrecos = ctx!.ConfiguracaoDePrecos;
                }
            }
        }

        private static JsonSerializerOptions ObterConfiguracoes()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;
            opcoes.ReferenceHandler = ReferenceHandler.Preserve;

            return opcoes;
        }
    }
}
