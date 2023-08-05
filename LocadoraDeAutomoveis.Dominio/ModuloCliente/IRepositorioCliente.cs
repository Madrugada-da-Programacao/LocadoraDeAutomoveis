namespace LocadoraDeAutomoveis.Dominio.ModuloCliente
{
	public interface IRepositorioCliente : IRepositorio<Cliente>
	{
		Cliente? SelecionarPorNomeETipoDeCliente(string nome, Cliente.TipoDeCliente tipoDeCliente);
	}
}
