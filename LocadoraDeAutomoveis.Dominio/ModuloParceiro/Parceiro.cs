namespace LocadoraDeAutomoveis.Dominio.ModuloParceiro
{
	public class Parceiro : EntidadeBase<Parceiro>
	{
		public string Nome { get; set; } = "";

		public Parceiro()
		{
		}

		public Parceiro(string nome)
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
