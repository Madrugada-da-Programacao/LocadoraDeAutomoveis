using static LocadoraDeAutomoveis.Dominio.Cliente;

namespace LocadoraDeAutomoveis.Dominio.ModuloCliente
{
	public interface IRepositorioCliente : IRepositorio<Cliente>
	{
		Cliente? SelecionarPorNomeETipoDeCliente(string nome, TipoDeCliente tipoDeCliente);
	}
}
