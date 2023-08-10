using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using System.ComponentModel;

namespace LocadoraDeAutomoveis.Dominio.ModuloAutomovel
{
	public class Automovel : EntidadeBase<Automovel>
    {
        public string Placa { get; set; } = "";
        public string Marca { get; set; } = "";
        public string Cor { get; set; } = "";
        public string Modelo { get; set; } = "";
		public TiposDeCombustivel TipoCombustivel { get; set; }
        public float CapacidadeCombustivel { get; set; } = 1;
        public DateTime Ano { get; set; } = DateTime.Now.AddDays(-1);

        public float KM { get; set; }

        public byte[] Imagem { get; set; } = new byte[] { 1, 2};

		public GrupoDeAutomoveis GrupoDeAutomovel { get; set; }

        public Automovel() { }
        public Automovel(string placa, string marca, string cor, string modelo, TiposDeCombustivel tipoCombustivel, float capacidadeCombustivel, DateTime ano, float kM, byte[] imagem, GrupoDeAutomoveis grupoDeAutomovel)
        {
            Placa = placa;
            Marca = marca;
            Cor = cor;
            Modelo = modelo;
            TipoCombustivel = tipoCombustivel;
            CapacidadeCombustivel = capacidadeCombustivel;
            Ano = ano;
            KM = kM;
            Imagem = imagem;
            GrupoDeAutomovel = grupoDeAutomovel;
        }
        public Automovel(Guid ID,string placa, string marca, string cor, string modelo, TiposDeCombustivel tipoCombustivel, float capacidadeCombustivel, DateTime ano, float kM, byte[] imagem, GrupoDeAutomoveis grupoDeAutomovel) : this(placa, marca, cor, modelo, tipoCombustivel, capacidadeCombustivel, ano, kM, imagem, grupoDeAutomovel)
        {
            this.Id = ID;
        }

        public enum TiposDeCombustivel
        {
            [Description("Gasolina")]
            Gasolina = 0,
            [Description("Gás")]
			Gas = 1,
            [Description("Diesel")]
            Diesel = 2,
            [Description("Álcool")]
			Alcool = 3
        }
    }
}
