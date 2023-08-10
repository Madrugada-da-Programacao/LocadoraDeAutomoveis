using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloTaxaOuServico
{
	public class MapeadorTaxaOuServicoOrm : IEntityTypeConfiguration<TaxaOuServico>
	{
		public void Configure(EntityTypeBuilder<TaxaOuServico> builder)
		{
			builder.ToTable("TBTaxaOuServico");

			builder.Property(t => t.Id).IsRequired().ValueGeneratedNever();
			
			builder.Property(t => t.Nome).HasColumnType("varchar(100)").IsRequired();

			builder.Property(t => t.Preco).HasColumnType("decimal(18, 2)").IsRequired();

			builder.Property(t => t.TipoCobranca).HasConversion<int>().IsRequired();

		}
	}
}
