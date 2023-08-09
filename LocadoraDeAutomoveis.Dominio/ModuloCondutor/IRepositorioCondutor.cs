namespace LocadoraDeAutomoveis.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorio<Condutor>
	{
		Condutor? SelecionarPorNome(string nome);
    }
}
