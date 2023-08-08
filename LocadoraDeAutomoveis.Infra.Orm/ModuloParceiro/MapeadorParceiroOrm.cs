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
		}
	}
}
