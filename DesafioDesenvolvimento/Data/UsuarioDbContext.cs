using DesafioDesenvolvimento.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesafioDesenvolvimento.Data
{
    public class UsuarioDbContext : IdentityDbContext<Usuario>
    {
        public UsuarioDbContext (DbContextOptions<UsuarioDbContext>opts) : base(opts) { }   
    }
}
