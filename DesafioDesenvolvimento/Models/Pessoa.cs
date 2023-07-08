using System.ComponentModel.DataAnnotations;

namespace DesafioDesenvolvimento.Models;

public class Pessoa
{
    [Key]
    [Required]

    public int Id { get; set; }

    [Required]
    [StringLength(100)]

    public string Nome { get; set; }
    [Required]
    [StringLength(11)]
    public string Cpf { get; set; }

    [Required]
    [StringLength(2)]
    public string Uf { get; set; }
    public DateTime Date { get; set; }
    public DateTime DateNascimento { get; set; }


}
