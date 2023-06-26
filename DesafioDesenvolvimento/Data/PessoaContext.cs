using DesafioDesenvolvimento.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioDesenvolvimento.Data;

public class PessoaContext : DbContext
{
    public PessoaContext(DbContextOptions<PessoaContext> opts) : base(opts)

    {

    }
    
    public DbSet<Pessoa> Pessoa { get; set; }   
}
