using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;

namespace DesafioDesenvolvimento.Models;

public class Pessoa
{
    [Key]
    [Required]

    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatorio")]
    [StringLength(100, ErrorMessage = "Nome pode ter no maximo 100 caracteres.")]

    public string Nome { get; set; }
    [Required(ErrorMessage = "O CPF é obrigatorio")]
    [StringLength(11, ErrorMessage = "O tamanho do CPF é de 11 digitos.")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "O UF é obrigatorio")]
    [StringLength(2, ErrorMessage = "O UF é somente 2 letras.")]
    public string UF { get; set; }
    public DateTime Date { get; set; }
    public DateTime DateNascimento { get; set; }


}
