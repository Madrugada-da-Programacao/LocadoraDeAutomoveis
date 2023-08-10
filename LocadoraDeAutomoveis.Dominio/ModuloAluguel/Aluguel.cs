using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloCupom;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;

namespace LocadoraDeAutomoveis.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase<Aluguel>
    {
        //funcionario cliente grupoauto planocobr condutor automovel
        // data locação devolucaoprevista kmdoautomovel cupomlist taxas taxasAdicionais valortotalTODO
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public GrupoDeAutomoveis GrupoDeAutomoveis { get; set; }
        public PlanoDeCobranca.TipoDeCobranca TipoDeCobranca { get; set; }
		public Condutor Condutor { get; set; }
        public Automovel Automovel { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int KmAutomovel { get; set; }
        public Cupom Cupom { get; set; }
        public List<TaxaOuServico> Taxas { get; set; }
        public List<TaxaOuServico> TaxasAdicionais { get; set; }
        public decimal ValorTotal { get; set; }

        public bool Aberto { get; set; }

        public Aluguel(Funcionario funcionario, Cliente cliente, GrupoDeAutomoveis grupoDeAutomoveis, PlanoDeCobranca.TipoDeCobranca tipoDeCobranca, Condutor condutor, Automovel automovel, DateTime dataLocacao, DateTime dataDevolucaoPrevista, int kmAutomovel, Cupom cupom, List<TaxaOuServico> taxas, List<TaxaOuServico> taxasAdicionais, decimal valorTotal)
        {
            Funcionario = funcionario;
            Cliente = cliente;
            GrupoDeAutomoveis = grupoDeAutomoveis;
			TipoDeCobranca = tipoDeCobranca;
            Condutor = condutor;
            Automovel = automovel;
            DataLocacao = dataLocacao;
            DataDevolucaoPrevista = dataDevolucaoPrevista;
            KmAutomovel = kmAutomovel;
            Cupom = cupom;
            Taxas = taxas;
            TaxasAdicionais = taxasAdicionais;
            ValorTotal = valorTotal;
        }

        public Aluguel()
        {
        }
    }
}
