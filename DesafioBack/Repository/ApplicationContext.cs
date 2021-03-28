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

            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
#if DEBUG
                var connectionString = configuration.GetConnectionString("DebugConnectionString");
#else
                var connectionString = configuration.GetConnectionString("DockerConnectionString");
#endif
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
