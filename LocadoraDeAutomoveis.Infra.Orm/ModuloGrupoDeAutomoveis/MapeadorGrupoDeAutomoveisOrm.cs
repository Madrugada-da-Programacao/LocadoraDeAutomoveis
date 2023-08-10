using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloGrupoDeAutomoveis
{
    public class MapeadorGrupoDeAutomoveisOrm : IEntityTypeConfiguration<GrupoDeAutomoveis>
    {
        public void Configure(EntityTypeBuilder<GrupoDeAutomoveis> builder)
        {
            builder.ToTable("TBGrupoDeAutomoveis");
            builder.Property(g => g.Id).IsRequired().ValueGeneratedNever();
            builder.Property(g => g.Nome).HasColumnType("varchar(100)").IsRequired();

			builder.HasOne(p => p.PlanoDeCobranca)
						.WithOne(p => p.GrupoDeAutomoveis)
						.IsRequired(false)
						.HasConstraintName("FK_TBGrupoDeAutomovel_TBPlanoDeCobranca")
						.OnDelete(DeleteBehavior.Restrict);
		}
    }
}
