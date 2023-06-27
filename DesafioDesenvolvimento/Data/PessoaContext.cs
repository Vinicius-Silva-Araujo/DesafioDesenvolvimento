using DesafioDesenvolvimento.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioDesenvolvimento.Data
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> opts) : base(opts)

        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>();
            base.OnModelCreating(modelBuilder); 
        }
    }
}