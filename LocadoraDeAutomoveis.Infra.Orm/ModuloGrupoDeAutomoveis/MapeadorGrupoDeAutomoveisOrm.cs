using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;

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

			builder.HasMany(grupoDeAutomoveis => grupoDeAutomoveis.Alugueis)
							.WithOne(aluguel => aluguel.GrupoDeAutomoveis)
							.IsRequired(false)
							.OnDelete(DeleteBehavior.NoAction);
		}
    }
}
