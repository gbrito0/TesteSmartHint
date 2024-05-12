using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<PessoaFisica> PessoaFisica { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridica { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pessoa>().UseTptMappingStrategy();
        }

    }
}
