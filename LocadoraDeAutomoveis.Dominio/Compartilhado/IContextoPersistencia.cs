namespace LocadoraDeAutomoveis.Dominio.Compartilhado
{
    public interface IContextoPersistencia // Unit of Work - UoW
	{
        void DesfazerAlteracoes();

        void GravarDados();
    }
}
