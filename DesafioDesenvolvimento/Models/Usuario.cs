using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DesafioDesenvolvimento.Models
{
    public class Usuario
    {
               
        public string UserName { get; set; }       
        public DateTime DataNascimento { get; set; }        
        public string Password { get; set; }        
        public string RePassword { get; set; }
    }
}