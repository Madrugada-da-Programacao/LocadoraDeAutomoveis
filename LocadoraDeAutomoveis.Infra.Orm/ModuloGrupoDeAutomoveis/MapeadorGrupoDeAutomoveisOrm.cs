using LocadoraDeAutomoveis.Dominio;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloGrupoDeAutomoveis
{
    public class MapeadorGrupoDeAutomoveisOrm : IEntityTypeConfiguration<GrupoDeAutomoveis>
    {
        public void Configure(EntityTypeBuilder<GrupoDeAutomoveis> builder)
        {
            builder.ToTable("TBGrupoDeAutomoveis");
            builder.Property(g => g.Id).IsRequired().ValueGeneratedNever();
            builder.Property(g => g.Nome).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
