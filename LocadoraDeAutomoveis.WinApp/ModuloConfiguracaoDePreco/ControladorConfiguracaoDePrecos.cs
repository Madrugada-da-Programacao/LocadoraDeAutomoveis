using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracaoDePrecos;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracaoDePrecos;

namespace LocadoraDeAutomoveis.WinApp.ModuloConfiguracaoDePreco
{
    public class ControladorConfiguracaoDePrecos : ControladorBase
    {


        private IRepositorioConfiguracaoDePrecos RepositorioConfiguracaoDePrecos { get; set; }
        private ServicoConfiguracaoDePrecos ServicoConfiguracaoDePrecos { get; set; }

        public ControladorConfiguracaoDePrecos(IRepositorioConfiguracaoDePrecos repositorioConfiguracaoDePrecos, ServicoConfiguracaoDePrecos servicoConfiguracaoDePrecos)
        {
            RepositorioConfiguracaoDePrecos = repositorioConfiguracaoDePrecos;
            ServicoConfiguracaoDePrecos = servicoConfiguracaoDePrecos;
        }

        public override void Inserir()
        {
            throw new NotImplementedException();
        }
        public override void Editar()
        {
            ConfiguracaoDePrecos registro = RepositorioConfiguracaoDePrecos.SelecionarRegistro();

            DialogConfiguracaoDePrecos dialog = new DialogConfiguracaoDePrecos();

            dialog.onGravarRegistro += ServicoConfiguracaoDePrecos.Editar;

            dialog.ConfiguracaoDePrecos = registro;

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {

            }
        }
        public override void Excluir()
        {
            throw new NotImplementedException();
        }



        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxConfiguracaoDePrecos();
        }

        public override UserControl ObtemListagem()
        {
            throw new NotImplementedException();
        }
    }
}
