using LocadoraDeAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloParceiro
{
	public class MapeadorParceiroOrm : IEntityTypeConfiguration<Parceiro>
	{
		public void Configure(EntityTypeBuilder<Parceiro> builder)
		{
			builder.ToTable("TBParceiro");

			builder.Property(p => p.Id).IsRequired().ValueGeneratedNever();

			builder.Property(p => p.Nome).HasColumnType("varchar(100)").IsRequired();

				builder.HasMany(p => p.Cupons)
					   .WithOne(c => c.Parceiro)
					   .IsRequired(false)
					   .OnDelete(DeleteBehavior.NoAction);
		}
	}
}
