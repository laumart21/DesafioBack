using DesafioBack.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBack.Configuration
{
    public class ParcelaConfiguration : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
            builder.ToTable("parcela");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Numero).HasColumnName("numero").IsRequired();
            builder.Property(p => p.Vencimento).HasColumnName("vencimento").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Valor).HasColumnName("valor").IsRequired();
        }
    }
}
