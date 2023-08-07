using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloPlanoDeCobranca
{
    public class MapeadorPlanoDeCobrancaOrm : IEntityTypeConfiguration<PlanoDeCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoDeCobranca> builder)
        {
            builder.ToTable("TBPlanoDeCobranca");

            builder.Property(p => p.Id).IsRequired().ValueGeneratedNever();

            builder.Property(p => p.TipoDoPlano).HasConversion<int>().IsRequired();

            builder.Property(t => t.PrecoDiaria).HasColumnType("decimal(18, 2)").IsRequired();

            builder.Property(t => t.PrecoKm).HasColumnType("decimal(18, 2)").IsRequired();

            builder.Property(p => p.KmDisponiveis).HasConversion<int>().IsRequired();
        }
    }
}