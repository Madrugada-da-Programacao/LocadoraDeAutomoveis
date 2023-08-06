using LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Infra.Dados.Arquivo.Compartilhado;

namespace LocadoraDeAutomoveis.Infra.Dados.Arquivo.ModuloConfiguracaoDePrecos
{
    public class RepositorioConfiguracaoDePrecosEmArquivo : IRepositorioConfiguracaoDePrecos
    {
        protected ContextoDados contextoDados;

        public RepositorioConfiguracaoDePrecosEmArquivo(ContextoDados contextoDados)
        {
            this.contextoDados = contextoDados;
        }

        public void Editar()
        {
            contextoDados.GravarEmArquivoJson();
        }

        public void Editar(ConfiguracaoDePrecos registro)
        {
            contextoDados.GravarEmArquivoJson();
        }

        public void Excluir(ConfiguracaoDePrecos registro)
        {
            throw new NotImplementedException();
        }

        public bool Existe(ConfiguracaoDePrecos registro)
        {
            throw new NotImplementedException();
        }

        public void Inserir(ConfiguracaoDePrecos novoRegistro)
        {
            throw new NotImplementedException();
        }

        public ConfiguracaoDePrecos? SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public ConfiguracaoDePrecos SelecionarRegistro()
        {
            return contextoDados.ConfiguracaoDePrecos;
        }

        public List<ConfiguracaoDePrecos> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}