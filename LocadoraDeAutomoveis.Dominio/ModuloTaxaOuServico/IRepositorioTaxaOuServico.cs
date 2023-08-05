namespace LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico
{
	public interface IRepositorioTaxaOuServico : IRepositorio<TaxaOuServico>
	{
		TaxaOuServico? SelecionarPorNome(string nome);
	}
}
