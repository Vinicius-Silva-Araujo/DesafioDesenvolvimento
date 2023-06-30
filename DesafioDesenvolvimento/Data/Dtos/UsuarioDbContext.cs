using DesafioDesenvolvimento.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace DesafioDesenvolvimento.Data.Dtos;

public class UsuarioDbContext 
{
    [PersonalData]
    public virtual IKey Id { get; set; }
    [ProtectedPersonalData]
    public virtual string UserName { get; set; }    
    [ProtectedPersonalData]
    public virtual string Email { get; set; }  
    [PersonalData] 
    public virtual string PasswordHash { get; set; }
    public virtual string SecurityStamp { get; set; }      
}
