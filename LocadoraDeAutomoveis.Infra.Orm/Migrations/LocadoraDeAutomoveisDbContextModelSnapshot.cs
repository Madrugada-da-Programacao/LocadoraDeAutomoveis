// <auto-generated />
using System;
using LocadoraDeAutomoveis.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocadoraDeAutomoveis.Infra.Orm.Migrations
{
    [DbContext(typeof(LocadoraDeAutomoveisDbContext))]
    partial class LocadoraDeAutomoveisDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocadoraDeAutomoveis.Dominio.ModuloAutomovel.Automovel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<double>("CapacidadeCombustivel")
                        .HasColumnType("float");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<Guid>("FK_Automovel_GrupoDeAutomoveis")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Imagem")
                        .IsRequired()
                        .HasMaxLength(2097152)
                        .HasColumnType("varbinary(max)");

                    b.Property<double>("KM")
                        .HasColumnType("float");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(12)");

                    b.Property<int>("TipoCombustivel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FK_Automovel_GrupoDeAutomoveis");

                    b.ToTable("TBAutomovel", (string)null);
                });

            modelBuilder.Entity("LocadoraDeAutomoveis.Dominio.ModuloCliente.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("NumeroDoDocumento")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int>("TipoCliente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TBCliente", (string)null);
                });

            modelBuilder.Entity("LocadoraDeAutomoveis.Dominio.ModuloCupom.Cupom", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("ParceiroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ParceiroId");

                    b.ToTable("TBCupom", (string)null);
                });

            modelBuilder.Entity("LocadoraDeAutomoveis.Dominio.ModuloFuncionario.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Salario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TBFuncionario", (string)null);
                });

            modelBuilder.Entity("LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis.GrupoDeAutomoveis", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoDeAutomoveis", (string)null);
                });

            modelBuilder.Entity("LocadoraDeAutomoveis.Dominio.ModuloParceiro.Parceiro", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBParceiro", (string)null);
                });

            modelBuilder.Entity("LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca.PlanoDeCobranca", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GrupoDeAutomoveisId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("KmDisponiveisKmControlado")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoDiariaKmControlado")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PrecoDiariaKmLivre")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PrecoDiariaPlanoDiario")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PrecoKmExtrapoladoKmControlado")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PrecoKmPlanoDiario")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoDeAutomoveisId")
                        .IsUnique();

                    b.ToTable("TBPlanoDeCobranca", (string)null);
                });

            modelBuilder.Entity("LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico.TaxaOuServico", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("TipoCobranca")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TBTaxaOuServico", (string)null);
                });

            modelBuilder.Entity("LocadoraDeAutomoveis.Dominio.ModuloAutomovel.Automovel", b =>
                {
                    b.HasOne("LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis.GrupoDeAutomoveis", "GrupoDeAutomovel")
                        .WithMany()
                        .HasForeignKey("FK_Automovel_GrupoDeAutomoveis")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoDeAutomovel");
                });

            modelBuilder.Entity("LocadoraDeAutomoveis.Dominio.ModuloCupom.Cupom", b =>
                {
                    b.HasOne("LocadoraDeAutomoveis.Dominio.ModuloParceiro.Parceiro", "Parceiro")
                        .WithMany("Cupons")
                        .HasForeignKey("ParceiroId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_TBCupom_TBParceiro");

                    b.Navigation("Parceiro");
                });

            modelBuilder.Entity("LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca.PlanoDeCobranca", b =>
                {
                    b.HasOne("LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis.GrupoDeAutomoveis", "GrupoDeAutomoveis")
                        .WithOne("PlanoDeCobranca")
                        .HasForeignKey("LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca.PlanoDeCobranca", "GrupoDeAutomoveisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_TBPlanoDeCobranca_TBGrupoDeAutomovel");

                    b.Navigation("GrupoDeAutomoveis");
                });

            modelBuilder.Entity("LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis.GrupoDeAutomoveis", b =>
                {
                    b.Navigation("PlanoDeCobranca")
                        .IsRequired();
                });

            modelBuilder.Entity("LocadoraDeAutomoveis.Dominio.ModuloParceiro.Parceiro", b =>
                {
                    b.Navigation("Cupons");
                });
#pragma warning restore 612, 618
        }
    }
}
