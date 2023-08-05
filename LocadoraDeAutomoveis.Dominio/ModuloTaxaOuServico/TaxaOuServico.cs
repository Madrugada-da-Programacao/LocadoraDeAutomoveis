using System.ComponentModel;

namespace LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico
{
	public class TaxaOuServico : EntidadeBase<TaxaOuServico>
	{
		public enum TipoDeCobranca
		{
			[Description("Preço Fixo")]
			PrecoFixo = 0,

			[Description("Cobrança Diária")]
			CobrancaDiaria = 1
		}

		public string Nome { get; set; } = "";

		public decimal Preco { get; set; } = 0.01m;

		public TipoDeCobranca TipoCobranca { get; set; }

		public TaxaOuServico()
		{
		}

		public TaxaOuServico(string nome, decimal preco, TipoDeCobranca tipoCobranca)
		{
			Nome = nome;
			Preco = preco;
			TipoCobranca = tipoCobranca;
		}

		public TaxaOuServico(Guid id, string nome, decimal preco, TipoDeCobranca tipoCobranca) :
			this(nome, preco, tipoCobranca)
		{
			this.Id = id;
		}
	}
}
