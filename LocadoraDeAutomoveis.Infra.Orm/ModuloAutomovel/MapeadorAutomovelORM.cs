using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloAutomovel
{
    public class MapeadorAutomovelorm : IEntityTypeConfiguration<Automovel>
    {
        public void Configure(EntityTypeBuilder<Automovel> builder)
        {
            builder.ToTable("TBAutomovel");
            builder.Property(A => A.Id).IsRequired().ValueGeneratedNever();
            builder.Property(A => A.Placa).HasColumnType("varchar(12)").IsRequired();
            builder.Property(A => A.Marca).HasColumnType("varchar(20)").IsRequired();
            builder.Property(A => A.Cor).HasColumnType("varchar(60)").IsRequired();
            builder.Property(A => A.Modelo).HasColumnType("varchar(60)").IsRequired();
            builder.Property(A => A.TipoCombustivel).HasConversion<int>().IsRequired();
            builder.Property(A => A.CapacidadeCombustivel).HasColumnType("float").IsRequired();
            builder.Property(A => A.Ano).HasColumnType("varchar(15)").IsRequired();
            builder.Property(A => A.KM).HasColumnType("float").IsRequired();
            builder.Property(A => A.Imagem).HasColumnType("varbinary(max)").HasMaxLength(2 * 1024 * 1024).IsRequired();
            builder.HasOne(A => A.GrupoDeAutomovel).WithMany().HasForeignKey("FK_Automovel_GrupoDeAutomoveis");
        }
    }
}
