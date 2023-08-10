using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraDeAutomoveis.Dominio.ModuloCupom
{
	public class Cupom : EntidadeBase<Cupom>
	{
		public string Nome { get; set; } = "";
		public decimal Preco { get; set; } = 0.01m;
		public DateTime DataValidade { get; set; } = DateTime.Now;
		public Parceiro? Parceiro { get; set; }
		public Aluguel Aluguel { get; set; }

		public Cupom()
		{
		}

		public Cupom(string nome, decimal preco, DateTime dataValidade, Parceiro? parceiro)
		{
			Nome = nome;
			Preco = preco;
			DataValidade = dataValidade;
			Parceiro = parceiro;
		}

		public Cupom(Guid id, string nome, decimal preco, DateTime dataValidade, Parceiro? parceiro) :
			this(nome, preco, dataValidade, parceiro)
		{
			this.Id = id;
		}
	}
}
