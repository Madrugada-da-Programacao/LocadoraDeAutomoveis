namespace LocadoraDeAutomoveis.WinApp.Compartilhado
{
    public abstract class ControladorBase
    {
        protected string mensagemRodape;

        public abstract void Inserir();

        public virtual void Editar() { }

        public abstract void Excluir();

        public abstract UserControl ObtemListagem();

        public abstract ConfiguracaoToolboxBase ObtemConfiguracaoToolbox();

        public string ObterMensagemRodape()
        {
            return mensagemRodape;
        }
    }
}
