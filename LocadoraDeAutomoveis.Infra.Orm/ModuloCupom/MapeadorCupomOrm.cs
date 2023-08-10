using LocadoraDeAutomoveis.Dominio.ModuloCupom;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloCupom
{
	public class MapeadorCupomOrm : IEntityTypeConfiguration<Cupom>
	{
		public void Configure(EntityTypeBuilder<Cupom> builder)
		{
			builder.ToTable("TBCupom");

			builder.Property(c => c.Id).IsRequired().ValueGeneratedNever();

			builder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();

			builder.Property(c => c.Preco).HasColumnType("decimal(18, 2)").IsRequired();

			builder.Property(c => c.DataValidade).HasColumnType("datetime").IsRequired();

			builder.HasOne(c => c.Parceiro)
						.WithMany(p => p.Cupons)
						.IsRequired(false)
						.HasConstraintName("FK_TBCupom_TBParceiro")
						.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
