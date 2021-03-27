using DesafioBack.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBack.Repository
{
    public class ApplicationContext : DbContext
    {
        private readonly ILoggerFactory _logger = LoggerFactory.Create(c => c.AddConsole());

        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }

        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_logger).EnableSensitiveDataLogging();
            //optionsBuilder.UseSqlServer("Data source=(localdb)\\mssqllocaldb;Initial Catalog=DesafioBack;Integrated Security=true");
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            //modelBuilder.ApplyConfiguration(new TituloConfiguration());
            //modelBuilder.ApplyConfiguration(new ParcelaConfiguration());

            /*
            modelBuilder.Entity<Titulo>(p => 
            {
                p.ToTable("titulo");
                p.HasKey(p => p.Id);
                p.Property(p => p.Numero).HasColumnName("numero").IsRequired();
                p.Property(p => p.Cpf).HasColumnName("cpf").HasColumnType("CHAR(11)").IsRequired();
                p.Property(p => p.Nome).HasColumnName("nome").HasColumnType("VARCHAR(80)").IsRequired();
                p.Property(p => p.Juros).HasColumnName("juros");
                p.Property(p => p.Multa).HasColumnName("multa");
                p.HasIndex(i => i.Cpf).HasDatabaseName("idx_titulo_cpf");
                p.HasMany(p => p.Parcelas).WithOne(p => p.Titulo).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Parcela>(p =>
            {
                p.ToTable("parcela");
                p.HasKey(p=>p.Id);
                p.Property(p => p.Numero).HasColumnName("numero").IsRequired();
                p.Property(p => p.Vencimento).HasColumnName("vencimento").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd().IsRequired();
                p.Property(p => p.Valor).HasColumnName("valor").IsRequired();

                

            });
            */
        }
    }
}
