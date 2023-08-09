using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloPlanoDeCobranca
{
    public class MapeadorPlanoDeCobrancaOrm : IEntityTypeConfiguration<PlanoDeCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoDeCobranca> builder)
        {
            builder.ToTable("TBPlanoDeCobranca");

            builder.Property(p => p.Id).IsRequired().ValueGeneratedNever();

            builder.Property(p => p.PrecoDiariaPlanoDiario).HasColumnType("decimal(18, 2)").IsRequired();

            builder.Property(p => p.PrecoKmPlanoDiario).HasColumnType("decimal(18, 2)").IsRequired();

            builder.Property(p => p.PrecoDiariaKmControlado).HasColumnType("decimal(18, 2)").IsRequired();

            builder.Property(p => p.PrecoKmExtrapoladoKmControlado).HasColumnType("decimal(18, 2)").IsRequired();

            builder.Property(p => p.KmDisponiveisKmControlado).HasConversion<int>().IsRequired();

            builder.Property(p => p.PrecoDiariaKmLivre).HasColumnType("decimal(18, 2)").IsRequired();

            builder.HasOne(p => p.GrupoDeAutomoveis)
                        .WithOne()
                        .HasForeignKey<PlanoDeCobranca>(p => p.GrupoDeAutomoveisId)
                        .IsRequired(false)
                        .HasConstraintName("FK_TBPlanoDeCobranca_TBGrupoDeAutomovel")
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}