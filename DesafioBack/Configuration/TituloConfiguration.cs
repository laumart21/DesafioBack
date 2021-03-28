using DesafioBack.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBack.Configuration
{
    public class TituloConfiguration : IEntityTypeConfiguration<Titulo>
    {
        public void Configure(EntityTypeBuilder<Titulo> builder)
        {
            builder.ToTable("titulo");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Numero).HasColumnName("numero").IsRequired();
            builder.Property(p => p.Cpf).HasColumnName("cpf").HasColumnType("CHAR(11)").IsRequired();
            builder.Property(p => p.Nome).HasColumnName("nome").HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.Juros).HasColumnName("juros");
            builder.Property(p => p.Multa).HasColumnName("multa");
            builder.HasMany(p => p.Parcelas).WithOne(p => p.Titulo).OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(i => i.Cpf).HasDatabaseName("idx_titulo_cpf");
        }
    }
}
