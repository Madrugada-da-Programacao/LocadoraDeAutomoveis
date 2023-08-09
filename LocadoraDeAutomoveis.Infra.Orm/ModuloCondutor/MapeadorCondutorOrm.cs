using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloCondutor
{
    public class MapeadorCondutorOrm : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("TBCondutor");

            builder.Property(c => c.Id).IsRequired().ValueGeneratedNever();

            builder.Property(c => c.ClienteEhCondutor).HasColumnType("bit").IsRequired();

            builder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();

            builder.Property(c => c.Email).HasColumnType("varchar(100)").IsRequired();

            builder.Property(c => c.Telefone).HasColumnType("varchar(20)").IsRequired();

            builder.Property(c => c.Cpf).HasColumnType("varchar(20)").IsRequired();

            builder.Property(c => c.Cnh).HasColumnType("varchar(20)").IsRequired();

            builder.Property(f => f.Validade).HasColumnType("datetime").IsRequired();

            builder.HasOne(p => p.Cliente)
                        .WithOne(p => p.Condutor)
                        .IsRequired(false)
                        .HasConstraintName("FK_TBCondutor_TBCliente")
                        .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
