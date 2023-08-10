using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis
{
    public class GrupoDeAutomoveis : EntidadeBase<GrupoDeAutomoveis>
    {
        public string Nome { get; set; } = "";

        public PlanoDeCobranca PlanoDeCobranca { get; set; }
		public List<Aluguel> Alugueis { get; set; }

		public GrupoDeAutomoveis() { }
        public GrupoDeAutomoveis(string nome)
        {
            this.Nome = nome;
        }
        public GrupoDeAutomoveis(Guid id, string nome) : this(nome)
        {
            this.Id = id;
        }
        public override void Atualizar(GrupoDeAutomoveis registro)
        {
            Nome = registro.Nome;
        }
    }
}
