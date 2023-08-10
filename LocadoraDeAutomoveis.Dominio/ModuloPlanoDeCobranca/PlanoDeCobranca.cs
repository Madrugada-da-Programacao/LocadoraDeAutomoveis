using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca
{
    public class PlanoDeCobranca : EntidadeBase<PlanoDeCobranca>
    {
        public enum TipoDoPlanoEnum 
        {
            [Description("Plano Diário")]
            PlanoDiario = 0,

            [Description("Km Controlado")]
            KmControlado = 1,

            [Description("Km Livre")]
            KmLivre = 2,
        }

        public TipoDoPlanoEnum TipoDoPlano { get; set; }
        public GrupoDeAutomoveis GrupoDeAutomoveis { get; set; }
        public decimal PrecoDiariaPlanoDiario { get; set; } = 1m;
        public decimal PrecoKmPlanoDiario { get; set; } = 1m;
        public decimal PrecoDiariaKmControlado { get; set; } = 1m;
        public decimal PrecoKmExtrapoladoKmControlado { get; set; } = 1m;
        public int KmDisponiveisKmControlado { get; set; } = 1;
        public decimal PrecoDiariaKmLivre { get; set; } = 1m;

        public Guid GrupoDeAutomoveisId { get; set; }

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
