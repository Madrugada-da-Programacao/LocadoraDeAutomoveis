using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Dominio.ModuloAutomovel
{
    public class Automovel : EntidadeBase<Automovel>
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public TiposDeCombustivel TipoCombustivel { get; set; }
        public float CapacidadeCombustivel { get; set; }
        public string Ano { get; set; }

        public float KM { get; set; }

        public byte[] Imagem { get; set; }

        public Guid GrupoDeAutomovel { get; set; }

        public Automovel() { }
        public Automovel(string placa, string marca, string cor, string modelo, TiposDeCombustivel tipoCombustivel, float capacidadeCombustivel, string ano, float kM, byte[] imagem, Guid grupoDeAutomovel)
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
        public Automovel(Guid ID,string placa, string marca, string cor, string modelo, TiposDeCombustivel tipoCombustivel, float capacidadeCombustivel, string ano, float kM, byte[] imagem, Guid grupoDeAutomovel) : this(placa, marca, cor, modelo, tipoCombustivel, capacidadeCombustivel, ano, kM, imagem, grupoDeAutomovel)
        {
            this.Id = ID;
        }

        public enum TiposDeCombustivel
        {
            [Description("Gasolina")]
            Gasolina = 1,
            [Description("Etanol")]
            Etanol = 2,
            [Description("Diesel")]
            Diesel = 3,
            [Description("Elétrico")]
            Eletrico = 4,
            [Description("Etanol & GNV")]
            EtanolGas = 5,
            [Description("Gasolina & GNV")]
            GasolinaGas = 6,
            [Description("Total Flex")]
            Tflex = 7
        }
    }
}
