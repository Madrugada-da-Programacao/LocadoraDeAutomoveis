namespace LocadoraDeAutomoveis.Dominio
{
    public interface IContextoPersistencia
    {
        void DesfazerAlteracoes();

        void GravarDados();
    }
}
