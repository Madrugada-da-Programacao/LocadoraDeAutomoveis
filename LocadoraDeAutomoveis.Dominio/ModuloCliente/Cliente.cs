using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using System.ComponentModel;

namespace LocadoraDeAutomoveis.Dominio.ModuloCliente
{
	public class Cliente : EntidadeBase<Cliente>
	{
		public enum TipoDeCliente
		{
			[Description("Pessoa Física")]
			PessoaFisica = 0,

			[Description("Pessoa Jurídica")]
			PessoaJuridica = 1
		}

		public string Nome { get; set; } = "";
		public TipoDeCliente TipoCliente { get; set; }
		public string NumeroDoDocumento { get; set; } = "";
		public string Email { get; set; } = "";
		public string Telefone { get; set; } = "";
		public string Estado { get; set; } = "";
		public string Cidade { get; set; } = "";
		public string Bairro { get; set; } = "";
		public string Rua { get; set; } = "";
		public int Numero { get; set; } = 1;
		public Condutor Condutor { get; set; }

		public Cliente()
		{
		}

		public Cliente(string nome, TipoDeCliente tipoCliente, string numeroDoDocumento, string email,
			           string telefone, string estado, string cidade, string bairro, string rua, int numero)
		{
			Nome = nome;
			TipoCliente = tipoCliente;
			NumeroDoDocumento = numeroDoDocumento;
			Email = email;
			Telefone = telefone;
			Estado = estado;
			Cidade = cidade;
			Bairro = bairro;
			Rua = rua;
			Numero = numero;
		}

		public Cliente(Guid id, string nome, TipoDeCliente tipoCliente, string numeroDoDocumento, string email,
					   string telefone, string estado, string cidade, string bairro, string rua, int numero) :
			this(nome, tipoCliente, numeroDoDocumento, email, telefone, estado, cidade, bairro, rua, numero)
		{
			this.Id = id;
		}
	}
}
