using LocadoraDeAutomoveis.Dominio.ModuloCupom;

namespace LocadoraDeAutomoveis.Dominio.ModuloParceiro
{
	public class Parceiro : EntidadeBase<Parceiro>
	{
		public string Nome { get; set; } = "";
		public List<Cupom> Cupons { get; set; }

		public Parceiro()
		{
			Cupons = new List<Cupom>();
		}

		public Parceiro(string nome) : this()
		{
			Nome = nome;
		}

		public Parceiro(Guid id, string nome) :
			this(nome)
		{
			this.Id = id;
		}
	}
}
