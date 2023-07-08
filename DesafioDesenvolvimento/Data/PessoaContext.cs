﻿using DesafioDesenvolvimento.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesafioDesenvolvimento.Data
{
    public class PessoaContext : DbContext 
    {
        public PessoaContext(DbContextOptions<PessoaContext> opts) : base(opts) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>();
            base.OnModelCreating(modelBuilder); 
        }
        
    }
    //public class UsuarioDbContext : IdentityDbContext<Usuario>
    //{
    //    public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opts) : base(opts) { }

    //    public DbSet<Usuario> Usuarios { get; set; }
    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Usuario>();
    //        base.OnModelCreating(modelBuilder);
    //    }
    //}
}

