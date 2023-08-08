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

            builder.HasOne(m => m.GrupoDeAutomoveis)
                .WithOne(d => d.PlanoDeCobranca)
                .IsRequired()
                .HasConstraintName("FK_TBPlanoDeCobranca_TBGrupoDeAutomovel")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}