﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DesafioDesenvolvimento.Data.Dtos;

public class CreateUsuarioDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
    
}
