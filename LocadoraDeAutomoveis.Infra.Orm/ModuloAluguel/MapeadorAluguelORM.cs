using LocadoraDeAutomoveis.Dominio.ModuloAluguel;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloAluguel
{
	public class MapeadorAluguelORM : IEntityTypeConfiguration<Aluguel>
	{
		public void Configure(EntityTypeBuilder<Aluguel> builder)
		{
			builder.ToTable("TBAluguel");
			builder.Property(a => a.Id).IsRequired().ValueGeneratedNever();

			builder.HasOne(aluguel => aluguel.Funcionario)
						.WithMany(funcionario => funcionario.Alugueis)
						.IsRequired(false)
						.HasConstraintName("FK_TBAluguel_TBFuncionario")
						.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(aluguel => aluguel.Cliente)
						.WithMany(cliente => cliente.Alugueis)
						.IsRequired(false)
						.HasConstraintName("FK_TBAluguel_TBCliente")
						.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(aluguel => aluguel.GrupoDeAutomoveis)
						.WithMany(grupoDeAutomoveis => grupoDeAutomoveis.Alugueis)
						.IsRequired(false)
						.HasConstraintName("FK_TBAluguel_TBGrupoDeAutomoveis")
						.OnDelete(DeleteBehavior.Restrict);

			builder.Property(a => a.TipoDeCobranca).HasConversion<int>().IsRequired();

			builder.HasOne(aluguel => aluguel.Condutor)
						.WithMany(condutor => condutor.Alugueis)
						.IsRequired(false)
						.HasConstraintName("FK_TBAluguel_TBCondutor")
						.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(aluguel => aluguel.Automovel)
						.WithMany(automovel => automovel.Alugueis)
						.IsRequired(false)
						.HasConstraintName("FK_TBAluguel_TBAutomovel")
						.OnDelete(DeleteBehavior.Restrict);

			builder.Property(a => a.DataLocacao).HasColumnType("datetime").IsRequired();
			builder.Property(a => a.DataDevolucaoPrevista).HasColumnType("datetime").IsRequired();
			builder.Property(a => a.DataDevolucao).HasColumnType("datetime").IsRequired();
			builder.Property(a => a.KmAutomovel).HasConversion<int>().IsRequired();

			builder.HasOne(aluguel => aluguel.Cupom)
						.WithOne(cupom => cupom.Aluguel)
						.IsRequired(false)
						.HasConstraintName("FK_TBAluguel_TBCupom")
						.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(aluguel => aluguel.Taxas)
						.WithMany(taxaOuServico => taxaOuServico.Alugueis)
						.UsingEntity(x => x.ToTable("TBAluguel_TBTaxaOuServico"));

			builder.HasMany(aluguel => aluguel.TaxasAdicionais)
						.WithMany(taxaOuServico => taxaOuServico.Alugueis)
						.UsingEntity(x => x.ToTable("TBAluguel_TBTaxaOuServicoAdicionais"));

			builder.Property(a => a.ValorTotal).HasColumnType("decimal(18, 2)").IsRequired();
			builder.Property(a => a.Aberto).HasColumnType("bit").IsRequired();
		}
	}
}
