using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using System.ComponentModel;

namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca
{
    public class PlanoDeCobranca : EntidadeBase<PlanoDeCobranca>
    {

        public GrupoDeAutomoveis GrupoDeAutomoveis { get; set; }
        public decimal PrecoDiariaPlanoDiario { get; set; }
        public decimal PrecoKmPlanoDiario { get; set; }
        public decimal PrecoDiariaKmControlado { get; set; }
        public decimal PrecoKmExtrapoladoKmControlado { get; set; }
        public int KmDisponiveisKmControlado { get; set; }
        public decimal PrecoDiariaKmLivre { get; set; }

        public PlanoDeCobranca()
        {
        }

        public PlanoDeCobranca(GrupoDeAutomoveis grupoDeAutomoveis, decimal precoDiariaPlanoDiario, decimal precoKmPlanoDiario, decimal precoDiariaKmControlado, decimal precoKmExtrapoladoKmControlado, int kmDisponiveisKmControlado, decimal precoDiariaKmLivre)
        {
            GrupoDeAutomoveis = grupoDeAutomoveis;
            PrecoDiariaPlanoDiario = precoDiariaPlanoDiario;
            PrecoKmPlanoDiario = precoKmPlanoDiario;
            PrecoDiariaKmControlado = precoDiariaKmControlado;
            PrecoKmExtrapoladoKmControlado = precoKmExtrapoladoKmControlado;
            KmDisponiveisKmControlado = kmDisponiveisKmControlado;
            PrecoDiariaKmLivre = precoDiariaKmLivre;
        }
    }
}
