using System.ComponentModel;

namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca
{
    public class PlanoDeCobranca : EntidadeBase<PlanoDeCobranca>
    {
        public enum TipoDoPlanoEnum
        {
            [Description("Plano Diário")]
            PlanoDiario = 0,

            [Description("Plano Km Controlado")]
            PlanoKmControlado = 1,

            [Description("Plano Km Livre")]
            PlanoKmLivre = 2
        }

        //public GrupoDeAutomoveis GrupoDeAutomoveis { get; set; }
        public TipoDoPlanoEnum TipoDoPlano { get; set; }
        public decimal PrecoDiaria { get; set; }
        public decimal PrecoKm { get; set; }
        public int KmDisponiveis { get; set; }
    }
}
