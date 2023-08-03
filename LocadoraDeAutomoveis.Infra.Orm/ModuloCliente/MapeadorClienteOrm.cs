using LocadoraDeAutomoveis.Dominio;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloCliente
{
	public class MapeadorClienteOrm : IEntityTypeConfiguration<Cliente>
	{
		public void Configure(EntityTypeBuilder<Cliente> builder)
		{
			builder.ToTable("TBCliente");
			builder.Property(c => c.Id).IsRequired().ValueGeneratedNever();
			builder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();

			builder.Property(c => c.TipoCliente).HasConversion<int>().IsRequired();

			builder.Property(c => c.NumeroDoDocumento).HasColumnType("varchar(20)").IsRequired();
			builder.Property(c => c.Email).HasColumnType("varchar(100)").IsRequired();
			builder.Property(c => c.Telefone).HasColumnType("varchar(20)").IsRequired();
			builder.Property(c => c.Estado).HasColumnType("varchar(100)").IsRequired();
			builder.Property(c => c.Cidade).HasColumnType("varchar(100)").IsRequired();
			builder.Property(c => c.Bairro).HasColumnType("varchar(100)").IsRequired();
			builder.Property(c => c.Rua).HasColumnType("varchar(100)").IsRequired();

			builder.Property(c => c.Numero).HasConversion<int>().IsRequired();
		}
	}
}
