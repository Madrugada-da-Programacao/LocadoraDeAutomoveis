using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloFuncionario
{
    internal class MapeadorFuncionarioOrm : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> funcionarioBuilder)
        {
            funcionarioBuilder.ToTable("TBFuncionario");

            funcionarioBuilder.Property(f => f.Id).IsRequired().ValueGeneratedNever();

            funcionarioBuilder.Property(f => f.Nome).HasColumnType("varchar(100)").IsRequired();

            funcionarioBuilder.Property(f => f.DataAdmissao).HasColumnType("datetime").IsRequired();

            funcionarioBuilder.Property(f => f.Salario).HasColumnType("int").IsRequired();
        }
    }
}
